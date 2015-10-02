Function TestEnvPath($relPAth)
{
    foreach ($dir in $env:Path.Split(';'))
    {
        if (Test-Path (Join-Path $dir $relPAth))
        {
            return $true;
        }
    }

    return $false;
}

Function RunOpenCover($configuration)
{
    $files = """"+ ($(Resolve-Path "tests\*\bin\$configuration\*.Tests.dll" -Relative) -join """ """) + """";

    If (TestEnvPath("nunit-console.exe"))
    {
        $nunitRunner = "nunit-console.exe";
    }
    Else
    {
        $nunitRunner = $(Resolve-Path "packages\NUnit.Runners*\tools\nunit-console.exe" -Relative);
    }
    
    
    $openCover = (Resolve-Path "packages\OpenCover*\tools\OpenCover.Console.exe" -Relative)
    & "$openCover" -register:user `
    -target:"$nunitRunner" `
    -targetargs:"$files /noshadow" `
    -filter:"+[Faker*]* -[Faker.Tests]*" `
    -mergebyhash `
    -skipautoprops `
    -output:"opencoverCoverage.xml"
}


Function PostCoverage()
{
    $coveralls = (Resolve-Path "packages/coveralls.net.*/tools/csmacnz.coveralls.exe").ToString()
    & $coveralls --opencover `
    -i opencoverCoverage.xml `
    --repoToken $env:COVERALLS_REPO_TOKEN `
    --commitId $env:APPVEYOR_REPO_COMMIT `
    --commitBranch $env:APPVEYOR_REPO_BRANCH `
    --commitAuthor $env:APPVEYOR_REPO_COMMIT_AUTHOR `
    --commitEmail $env:APPVEYOR_REPO_COMMIT_AUTHOR_EMAIL `
    --commitMessage $env:APPVEYOR_REPO_COMMIT_MESSAGE `
    --jobId $env:APPVEYOR_JOB_ID
}

Function GenerateCoverage()
{
    $reportGenerator = (Resolve-Path "packages/ReportGenerator*/tools/ReportGenerator.exe");
    & $reportGenerator `
    -assemblyFilters:"-*Tests" `
    -classFilters:"-Faker.JetBrains.Annotations.*;-Faker.Resources.*" `
    -reports:"opencoverCoverage.xml" `
    -targetdir:"CoverageReport"
}


RunOpenCover("Release");
If (Test-Path env:\APPVEYOR)
{
    PostCoverage;
}
Else
{
    New-Item -ErrorAction Ignore -ItemType directory "CoverageReport"
    GenerateCoverage;
}