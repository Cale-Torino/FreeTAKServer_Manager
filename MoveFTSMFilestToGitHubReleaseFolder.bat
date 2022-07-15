::Run App With Args
@ECHO OFF
cd /D %~dp0
start MoveFTSMFilestToGitHubReleaseFolder.exe -Test -Test2
pause