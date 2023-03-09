# RecruitmentApp
Backend for the HeRo app that makes the recruitment process in the company easier.

## Table of contents
* [Introduction](#introduction)
* [Used technologies](#used-technologies)
* [Features](#features)

## Introduction
This project is an app that is supposed to help recruiters in the company with the whole recruitment process. It enables posting job offers, applying for them, managing 
applicants, schedguling interviews and more.

## Used technologies
* .NET 6.0
* C#
* Swagger
* Entity Framework Core 6.0.6
* XUnit
* Hangfire

## Features
### User management
* Creating a new user
* Editing an existing user
* Deleting users' account
* Confirming an account by email
* Reseting your password by email
* Logging in
* Loggin out
* User authentication
* User authorization to certain methods using custom attributes and user roles
* Loading all users (paging and sorting included)
* Loading a specified user
* Loading all recruiters
* Loading all technicians

### Emails
* Linking your email account to your app account
* Viewing emails on your email account on the app
* Loading all the emails on the users' email account to the database every hour

### Skills - refers to skills that job offers require
* Creating a skill
* Editing a skill
* Deleting a skill
* Loading a list of existing skills

### Job offers
* Posting a job offer
* Editing a job offer
* Deleting a job offer
* Ending job offers before their ending date
* Loading information about a specified job offer
* Loading all public job offers (paging, filtering and sorting included)
* Loading all job offers - including the job offers that have been created, but haven't been published yet (paging, filtering and sorting included)

### Candidates
* Applying for a job offer
* Editing information about a candidate (including the recruitment stage and status)
* Deleting the candidate's application
* Assigning a recruiter to the candidate
* Assigning a tech to the candidate
* Adding notes about a candidate after a HR interview
* Adding notes about a candidate after a Tech interview
* Loading information about a specified candidate
* Loading all candidates for a specified job offer (paging, filtering and sorting included)

### Interviews
* Setting up an interview between an applicant and a specified worker
* Editing information about an interview
* Canceling an interview
* Loading information about a singular interview
* Loading all planned interviews (paging, filtering and sorting included)

### Tests
* Unit tests of almost all the services in the project

### Reports
* Generating reports about the amount of new applicants for specified job offers in the specified time frame
* Generating reports about the most popular set of skills included in the job offers
* Generating reports about the most popular job offers

### Other
* Logging user actions in the database
* Choosing a language
* Translating error and success messages to the chosen language
