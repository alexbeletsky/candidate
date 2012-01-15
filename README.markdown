# Candidate.NET
Simple and nice continuous delivery for .NET web applications.

## What does application do?

Simple, you create new site. You point the application to github repostitory (like, git@github.com:alexanderbeletsky/candidate.test.net.git), configure MsBuild options (like target, configuration) and IIS properties. Once it done, the application will clone your repository, build it, run all unit tests and create new IIS site for that. All you need to do is access it by URL.

When you do changes to sources of application, those changes are picked up, tested and deployed immediately.

## What environment for application?

It is typically installed on the production and staging servers where the target application is working. Alternately you can host it on dedicated server and provide options for remote deployment.

## Which project types supported?

ASP.NET MVC, WebForms but in general every configuration that supports batch build and xcopy deployment.

## Can I support different branches?

Yes. Say, 'master' is current production code, 'develop' is current staging code. You can setup 'Production' and 'Staging' sites for different branches. 

## Any additional software I need?

Candidate is very lightweight.. So, just nothing except Git.

## How to contribute?

Just fork the repository and send me a pull request. Please referer to [How to build](https://github.com/alexanderbeletsky/candidate.net/wiki/How-to-build) with build instructions.

## Credits

It's using wonderful [Bounce](https://github.com/alexanderbeletsky/bounce) framework for building and big [suite](https://github.com/alexanderbeletsky/candidate.net/tree/master/packages) of cool open source tools available by NuGet.
