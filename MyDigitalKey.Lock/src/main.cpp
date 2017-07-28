#include "Arduino.h"
#include <ESP8266WiFi.h>
#include <ESP8266HTTPClient.h>
#include <ESP8266WebServer.h>

/* wiring the MFRC522 to ESP8266 (ESP-12)
RST     = GPIO5
SDA(SS) = GPIO4
MOSI    = GPIO13
MISO    = GPIO12
SCK     = GPIO14
GND     = GND
3.3V    = 3.3V
*/

#define RST_PIN	5  // RST-PIN
#define SS_PIN	4  // SDA-PIN

#define LOCK_PIN 15

const char* GUID = "4edfb100-cef8-4153-ae95-c61082c6ddda";
const char* ssid = "MIC Dev Camp";
const char* pwd = "micdevcamp";

ESP8266WebServer server(80);

void open();
void close();
void handleOpen();
void handleClose();

bool isAuthorized(int rfid);

void setup()
{
    close();

    Serial.begin(115200);
    pinMode(LOCK_PIN, OUTPUT);

    IPAddress ip(10, 0, 128, 69);
    WiFi.config(IPAddress(10, 0, 128, 69),
                IPAddress(10, 0, 0, 1),
                IPAddress(255, 255, 0, 0));
    WiFi.mode(WIFI_STA);
    WiFi.begin(ssid, pwd);

    while (WiFi.status() != WL_CONNECTED)
    {
        delay(500);
    }
    Serial.println(WiFi.localIP());

    server.on("/open", handleOpen);
    server.on("/close", handleClose);
    server.begin();

    /*if(isAuthorized(1))
    {
        open();
    }*/
}

void loop()
{
    server.handleClient();
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

bool isAuthorized(int rfid)
{
    HTTPClient client;
    client.begin("http://mydigitalkeyweb.azurewebsites.net/api/authorization/" + String(GUID) + "/" + rfid);
    client.GET();
    String s = client.getString();
    client.end();
    return s == "true";
}
