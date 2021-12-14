::UNINSTALL
ECHO ON
:: 1.9.6.1;1.9.7
start cmd /k pip install -r requirements.txt&&python -m pip install FreeTAKServer[ui]==1.9.7
pause