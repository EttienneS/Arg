# needs an API key from Nuget.org to work 
# uncomment the following and add your key before first run:
# nuget setApiKey YOUR_KEY_HERE

Remove-Item *.nupkg -Force

nuget pack

$package = $(Get-ChildItem *.nupkg).Name

Write-Host
Write-Host "!!Built: $package!!"
Write-Host

nuget push $package -Source https://api.nuget.org/v3/index.json

Remove-Item *.nupkg -Force

Write-Host -NoNewLine 'Press any key to continue...';
$null = $Host.UI.RawUI.ReadKey('NoEcho,IncludeKeyDown');