Given /^the ninja has ([^"]*)$/ do |skill|
	Given %{I select "#{skill}" from "my_ninja"}
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