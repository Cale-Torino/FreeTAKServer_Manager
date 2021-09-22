### FreeTAKServer Manager

The FreeTAKServer Manager  specific for FTS version `1.9.1.5`

Make sure you have a clean Python install.

Make sure your python environment variable path is clean.

Due to changing config files etc. I have to compile a new version for every new FTS release.

FreeTAKServer Manager has the ability to:
* Start
* Stop
* Restart
* Install
* Uninstall
* start on startup
* send alert emails
* let the user test the API (localhost & custom)
* allow quick `MainConfig.py` & `config.py` edits
* Open a portforward testing page

.NET Framework 4.7.2
C# Windows Presentation Foundation
C# Winforms

# Release Notes

 [ Version:  V1.0.0.3 ]
 [ Date: 22nd September 2021 ]

* Added `pip install FreeTAKServer-UI==1.9.1.5` only
* Added dedicated directory check for 0kb `__init__.py` file and `logs` folder
* Check that Python installed now runs after the server is installed as well as on form load
* General bug fixes