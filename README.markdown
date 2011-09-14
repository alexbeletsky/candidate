# Candidate.NET
Simple and nice continuous delivery for .NET web applications.

## What is the goal?

The goal is to provide continuous delivery tool for open source .NET applications.

## How to get started?

Just deploy Candidate as usual IIS site, login and setup your continues delivery site.

## Why I created that?

I've used to use Jenkins for quite long time, I was happy with it. The problem is that Jenkins is Java application, that usually takes up to 700Mb of memory. On my restricted VPS environment 700Mb is pretty much resource. Moreover, I want to have one solid platform that I understand able to tweek and configure. Since .NET is my platform of choice I wanted continues delivery application working on .NET platform too.

## Have you seen CruiseControl.NET?

Yes, I've seen it and I don't like it. Is it still alive? Haven't heard about it for a while.

## What does application do?

Simple, you create new site. You point the application to github repostitory (like, git@github.com:alexanderbeletsky/candidate.test.net.git), configure MsBuild options (like target, configuration) and IIS properties. Once it done, the application will clone your repository, build it, run all unit tests and create new IIS site for that. All you need to do is access it by URL.

When you do changes to sources of application, those changes are picked up, tested and deployed immediately.

## What environment for application?

It is typically installed on the production and staging servers where the target application is working. Alternately you can host it on dedicated server and provide options for remote deployment.

## Which project types supported?

ASP.NET MVC, WebForms currently.

## Can I support different branches?

Yes. I prefer the model which says - 'master' is current production code, 'develop' is current staging code. You can setup 'Production' and 'Staging' sites for different branches. 

## Any additional software I need?

Candidate is very lightweight.. So, just nothing except Git.

## Credits

I'm using wonderful [Bounce](https://github.com/alexanderbeletsky/bounce) framework for building and big [suite](https://github.com/alexanderbeletsky/candidate.net/tree/master/packages) of cool open source tools available by NuGet.
