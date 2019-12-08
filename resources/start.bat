@echo off
cls

echo Starting server...

RustDedicated.exe -batchmode ^
-nographics ^
+rcon.web 1 ^
+server.hostname "Test Server" ^
+server.maxplayers 10 ^
+server.worldsize 1000 ^
+server.seed 1 ^
+rcon.password "test123" ^
-logfile "gamelog.txt" 