# SWARocketChatProject
Our SWA Project

1. Github Projekt Klonen
2. MySQL Installieren und in der Workbench Entweder durch EER Model Importieren oder durch scripte.(Pfad: )
3. Projekt in Visual Studio Öffnen
4. Connection String in appsettings.json anpassen (Default: server=10.0.2.2;port=3306;Database=ProjectRocketChat;user=root;password=root)
5. Rechtsklick auf das Projekt in Visual Studio -> Publish -> (Reiter)Publish -> Configure -> Settings:
Connection: Realse
Target Framework: netcoreapp2.0
Deployment Mode: Framework Dependent
Target Runtime: *Benötigte auswählen*
Databases Connection String nicht benutzen
Entity Framework Migrations nicht benutzen
Save
6. (Button)Publish zum Ordner
(Optional) 7. Ordner auf Linux Übertragen
8. Linux: https://www.microsoft.com/net/download/linux-package-manager/ubuntu18-04/sdk-current ->
Linux Version auswählen -> Befehle ausführen
9. (Ohne Server) dotnet <app_assembly>.dll(in unserem fall SWARocketchat.dll)
9. (Apache Alternative: https://docs.microsoft.com/de-de/aspnet/core/host-and-deploy/linux-apache?view=aspnetcore-2.1&tabs=aspnetcore2x)
9. (mit nginx Server) sudo apt-get install nginx
(alle weiteren schritte für nginx Server)
10. sudo service nginx start
11. /etc/nginx/sites-available/default öffnen mit Text Editor
12. Inhalt mit folgendem Ersetzen: 
server {
    listen        80;
    server_name   example.com *.example.com;
    location / {
        proxy_pass         http://localhost:5000;
        proxy_http_version 1.1;
        proxy_set_header   Upgrade $http_upgrade;
        proxy_set_header   Connection keep-alive;
        proxy_set_header   Host $http_host;
        proxy_cache_bypass $http_upgrade;
    }
}
13. sudo gedit /etc/systemd/system/kestrel-SWARocketchat.service
14. in datei folgedes einfügen: 

[Service]
WorkingDirectory=/var/LinuxPublish/SWARocketchat
ExecStart=/usr/bin/dotnet /var/LinuxPublish/SWARocketchat.dll
Restart=always
RestartSec=10  # Restart service after 10 seconds if dotnet service crashes
SyslogIdentifier=dotnet-example
User=www-data
Environment=ASPNETCORE_ENVIRONMENT=Production
Environment=DOTNET_PRINT_TELEMETRY_MESSAGE=false

[Install]
WantedBy=multi-user.target


15. Bedingt Pfade für WorkingDirectory und ExecStart nach dotnet anpassen
16. systemctl enable kestrel-SWARocketchat.service
17. systemctl start kestrel-SWARocketchat.service
18. systemctl status kestrel-SWARocketchat.service
















