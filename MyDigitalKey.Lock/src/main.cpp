#include "Arduino.h"
#include <ESP8266WiFi.h>
#include <ESP8266HTTPClient.h>
#include <ESP8266WebServer.h>
#include <SPI.h>
#include "WS2812FX.h"
#include "MFRC522.h"


/* wiring the MFRC522 to ESP8266 (ESP-12)
RST     = GPIO0
SDA(SS) = GPIO4
MOSI    = GPIO13
MISO    = GPIO12
SCK     = GPIO14
GND     = GND
3.3V    = 3.3V
*/

#define RST_PIN	16  // RST-PIN
#define SS_PIN	4  // SDA-PIN

#define LOCK_PIN 0

const char* GUID = "4edfb100-cef8-4153-ae95-c61082c6ddda";
const char* ssid = "MIC Dev Camp";
const char* pwd = "micdevcamp";

ESP8266WebServer server(80);
MFRC522 mfrc522(SS_PIN, RST_PIN);
WS2812FX ws2812fx = WS2812FX(1, 2, NEO_RGB + NEO_KHZ800);
unsigned long start = 0;

void open();
void open(int delay);
void close();
void handleOpen();
void handleClose();
void setColor(char r, char g, char b);

bool readRFID(int &rfid);
bool isAuthorized(int rfid);

void dump_byte_array(byte *buffer, byte bufferSize);

void setup()
{
    Serial.begin(74880);
    pinMode(LOCK_PIN, OUTPUT);

    IPAddress ip(10, 0, 128, 69);
    WiFi.config(IPAddress(10, 0, 128, 69),
                IPAddress(10, 0, 0, 1),
                IPAddress(255, 255, 0, 0));
    WiFi.mode(WIFI_STA);
    WiFi.begin(ssid, pwd);

    while (WiFi.status() != WL_CONNECTED)
    {
        Serial.print(".");
        delay(500);
    }
    Serial.println(WiFi.localIP());

    server.on("/open", handleOpen);
    server.on("/close", handleClose);
    server.begin();

    SPI.begin();
    delay(100);
    mfrc522.PCD_Init();

    ws2812fx.init();
    ws2812fx.start();
}

void loop()
{
    int rfid;
    bool found = readRFID(rfid);
    server.handleClient();

    if(start != 0)
    {
        unsigned long diff = millis() - start;
        if(diff >= 5000)
        {
            close();
            setColor(0, 0, 0);
            start = 0;
        }
    }

    if(found)
    {
        if(isAuthorized(rfid))
        {
            open();
            setColor(0, 255, 0);
            start = millis();
        }
        else
        {
            close();
            setColor(255, 0, 0);
        }
    }
}

void handleOpen()
{
    open();
    server.send(200);
}

void handleClose()
{
    close();
    server.send(200);
}

void open()
{
    digitalWrite(LOCK_PIN, HIGH);
}

void close()
{
    digitalWrite(LOCK_PIN, LOW);
}

bool readRFID(int &rfid)
{
    if (!mfrc522.PICC_IsNewCardPresent() || !mfrc522.PICC_ReadCardSerial())
    {
        return false;
    }
    rfid = *(int*)(mfrc522.uid.uidByte);
    return true;
}

bool isAuthorized(int rfid)
{
    setColor(255, 168, 0);
    HTTPClient client;
    client.begin("http://mydigitalkeyweb.azurewebsites.net/api/authorization/" + String(GUID) + "/" + rfid);
    client.GET();
    String s = client.getString();
    client.end();
    return s == "true";
}

void setColor(char r, char g, char b)
{
    ws2812fx.setColor(r, g, b);
    ws2812fx.service();
}
