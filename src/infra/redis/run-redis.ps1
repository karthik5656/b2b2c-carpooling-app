# run-redis.ps1

Write-Host "Initializing Carpooling Environment..." -ForegroundColor Cyan

# 1. DEFINE PATHS (Update this to point to your .csproj)
$projectPath = "../../app/Carpooling.App/Carpooling.App.Api.csproj"

# 2. EXTRACT PASSWORD using .NET CLI
# We ask dotnet to give us the secret directly
$secretOutput = dotnet user-secrets list --project $projectPath
$passwordLine = $secretOutput | Select-String "REDIS_PASSWORD"

if (-not $passwordLine) {
    Write-Error "Could not find REDIS_PASSWORD in User Secrets."
    exit 1
}

# Parse the value (Format is 'Key = Value')
$redisPass = $passwordLine.ToString().Split('=')[1].Trim()

# 3. SET ENVIRONMENT VARIABLE for the current session
$env:REDIS_PASSWORD = $redisPass
Write-Host "REDIS_PASSWORD loaded into session." -ForegroundColor Green

# 4. LAUNCH DOCKER
Write-Host "Starting Containers..." -ForegroundColor Cyan
docker-compose -f redis-docker-compose.yaml up -d

Write-Host "Services are running!" -ForegroundColor Green