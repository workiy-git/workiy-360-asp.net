module.exports = {
  apps: [
    {
      name: 'workiy-360-api',
      script: 'dotnet',
      args: 'Workiy-360.Api.dll',
      cwd: '/var/www/workiy-360-asp.net/Workiy-360.Api/',
      interpreter: 'none',
      instances: 1,
      autorestart: true,
      watch: false,
      max_memory_restart: '1G',
      env: {
        ASPNETCORE_ENVIRONMENT: 'Production',
        ASPNETCORE_URLS: 'http://*:8081'
      }
    }
  ]
}

