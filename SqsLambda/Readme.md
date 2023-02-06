# AWS Lambda Simple SQS Function Project

This starter project consists of:
* LmabdaHandler.cs - class file containing a class with a single function handler method
* aws-lambda-tools-defaults.json - default argument settings for use with Visual Studio and command line deployment tools for AWS


# publishing Lambda
There are may ways to publish from visual studio, commnand line publis+ manual upload

I have tried with build in release mode and then zip the dlls, keeping all the files in root level of zip and upload to lambda
couple of things to remember
- if your lambda function is configured with x86_64 cpu arch, then you have to target your C# project to build to x64 arch
- then keeping all you files in root level of zip file

create a file and then upload to lambda.

# checking logs
since we can't see console output, we are writing to Lambda logger, hence we can check logs on cloudWatch logs for our lambda function