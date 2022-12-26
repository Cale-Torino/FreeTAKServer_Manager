::INITIATE THE SERVER
ECHO OFF
start cmd /k python -m FreeTAKServer.controllers.services.FTS
::WHEN RUNNING THE SCRIPT FROM A DIFFERENT DRIVE ADD THE `/D` SWITCH TO YOUR CD COMMAND
CD /D C:\Software\python\Lib\site-packages\FreeTAKServer-UI
set FLASK_APP=run.py
::flask run
flask run --host=0.0.0.0
pause