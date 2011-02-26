require 'sqlite3'

Given /^the ninja has ([^"]*)$/ do |skill|
	Given %{I am on "home"}
	And %{I follow "Calculator"}
	And %{I select "#{skill}" from "my_ninja"}
end

When /^attacked by ([^"]*)$/ do |opponent|
  Given %{I select "#{opponent}" from "opponent"}
  When  %{I press "Calculate"}
end

Then /^the ninja should engage the opponent$/ do
  Then  %{I should see "Engage opponent"}
end

Then /^the ninja should run for his life$/ do
  Then  %{I should see "Run for his life"}
end


Given /^I have the following opponents with skills:$/ do |table|
 # table is a Cucumber::Ast::Table
  db = SQLite3::Database.new( "C:/temp/ninjacommander.db" )
  db.execute( "delete from Fighter where class = 'opponent'" )  
  table.hashes.each do | row |
	db.execute( "insert into Fighter ('Description', 'Strength', 'Class') values ('#{row['fighter']}', '#{row['skill']}', 'opponent')" )  
  end
  db.close
end

Given /^I have the following ninjas with skills:$/ do |table|
  # table is a Cucumber::Ast::Table
  db = SQLite3::Database.new( "C:/temp/ninjacommander.db" )
  db.execute( "delete from Fighter where class = 'ninja'" )  
  table.hashes.each do | row |
	db.execute( "insert into Fighter ('Description', 'Strength', 'Class') values ('#{row['fighter']}', '#{row['skill']}', 'ninja')" )  
  end
  db.close
end