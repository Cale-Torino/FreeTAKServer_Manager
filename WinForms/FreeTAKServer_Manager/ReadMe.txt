FreeTAKServer Manager

The FreeTAKServer Manager C# application was created to make using the current `v1.7` of FreeTAKServer more user friendly.

Don't install Python for all users otherwise there are path errors.

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
C# WinForms

 /*
 * ReleaseNotes.txt
 *
 * SAFE-TVIGIL
 *
 * @author     C.A Torino
 * @version    V1.0.0.1
 * @since      2021/04/12
 */

#Release Notes

- V1.0.0.1
- 12th April 2021

* About form added.
* EmailSetup form added.
* ReadMe form added.
* Test_API form added.
* Start, Stop, Restart, Install, Uninstall functions optimized.
* All child forms changed to the FixedToolWindow boarder style.
* Start on startup checkbox optimized.
* Send email alerts checkbox optimized.


TODO
- WPF version of FreeTAKServer_Manager.exe.
- Reduce code.
- Improve methods
- Move functions to .dll files to clean up exe code.

