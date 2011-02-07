﻿@f2
Feature: Addition
	In order to make my library grow
	As a registered user
	I want to add movies to the library

	Scenario: Add a movie
		Given I am on "home"
		When  I follow "Add Media" 
		And   I fill in "title" with "Young Frankenstein"
		And   I press "Submit"
		Then  I should see "Young Frankenstein"