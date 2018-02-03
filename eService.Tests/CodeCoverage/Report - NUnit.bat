..\\..\\packages\\OpenCover.4.6.519\\tools\\OpenCover.Console.exe -filter:"+[eService*]*  -[eService.Data*]*" -target:runtests.bat -register:user
..\\..\\packages\\ReportGenerator.3.1.2\\tools\\ReportGenerator.exe -reports:results.xml -targetdir:coverage

start "report" "%~dp0\coverage\index.htm"