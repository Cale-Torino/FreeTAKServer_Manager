FreeTAKServer Manager

The FreeTAKServer Manager C# application was created to make using the current `v1.7` of FreeTAKServer more user friendly.

Make sure you have a clean Python install.

Make sure your python environment variable path is clean. 

FreeTAKServer Manager has the ability to:
* Start
* Stop
* Restart
* Install
* Uninstall

It can also:
* start on startup
* send alert emails
* let the user test the API (localhost & custom)
* allow quick `MainConfig.py` & `config.py` edits
* Open a portforward testing page

.NET Framework 4.7.2
C# Windows Presentation Foundation

 /*
 * ReleaseNotes.txt
 *
 * SAFE-TVIGIL
 *
 * @author     C.A Torino
 * @version    V1.0.0.1
 * @since      2021/04/14
 */

#Release Notes

- V1.0.0.1
- 14th April 2021

* About Window added.
* EmailSetup Window added.
* ReadMe Window added.
* Test_API Window added.
* Start, Stop, Restart, Install, Uninstall functions optimized.
* All child forms changed to the FixedToolWindow boarder style.
* Start on startup checkbox optimized.
* Send email alerts checkbox optimized.
* Code works with WPF (small modifications)

- Bugs
* Fixed bug where copying text would turn text black (looking transparent Richtextbox)
* Fixed bug where Test API buttons were mismatched



TODO
- Reduce code.
- Improve methods
- Move functions to .dll files to clean up exe code.

PORTS

UI GUI: 5000

API: 19023

COT TCP: 8087

COT SSL: 8089

Federation: 9000

HTTP DP: 8080

SSL DP: 8443