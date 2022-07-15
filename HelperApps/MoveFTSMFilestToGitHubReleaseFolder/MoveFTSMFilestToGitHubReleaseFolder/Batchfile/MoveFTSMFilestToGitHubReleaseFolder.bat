::Run App With Args
@ECHO OFF
cd /D %~dp0
start MoveFTSMFilestToGitHubReleaseFolder.exe -1.0.0.7
pause