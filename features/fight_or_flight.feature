﻿@ninja
Feature: Fight or flight
	As a ninja commander
	I want my ninjas to decide whether to take on an opponent 
		based on their skill levels
	so I can increase the ninja survival rate
	
	Background:
		And   I am on "home"
		When  I follow "Calculator" 
	
	Scenario: Weaker opponent
		Given the ninja has a third level black-belt
		When attacked by a samurai
		Then the ninja should engage the opponent
		
	Scenario: Stronger opponent
		Given the ninja has a third level black-belt
		When attacked by Chuck Norris
		Then the ninja should run for his life
				