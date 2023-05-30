::UNINSTALL
ECHO ON
:: 1.9.6.1;1.9.7;1.9.8.6;1.9.9;2.0.21;2.0.69
start cmd /k pip install -r requirements.txt&&python -m pip install FreeTAKServer[ui]==2.0.69
pause