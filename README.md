## DevCamp2017-Team8
# My Digital Key

### In a nutshell
My Digital Key is a hackaton's project whose aim is to allow the opening of connected locks with RFID badges. Those openings should be controllable with Authorizations set on a website.

### What is implemented
* RFID Badge detection
* Web server requests
* Authorizations linking badges and locks, with base time management
* Ability to suspend, resume and revoke authorisations
* A small web server on the lock to access and force opening/closing of the lock

### What needs to be implemented
* A user login on the website
* A way to securise RFID credentials
* A better management of authorizations (pretty much like a calendar app with repetitions)
* Possibility to have several houses to organize locks and authorizations
* Adding a new badge by selecting a scanning lock and saving the RFID credential
* Logging of all events
* A mobile app to send notifications when unauthorized people try to open a door (and the ability to grant rights on the go)

### Technologies used
* ASP.NET core for the API and the administration tools
