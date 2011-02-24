Given /^the ninja has ([^"]*)$/ do |skill|
	Given %{I select "#{skill}" from "my_ninja"}
end

When /^attacked by a ([^"]*)$/ do |opponent|
  Given %{I select "#{opponent}" from "opponent"}
  When  %{I press "Calculate"}
end

Then /^the ninja should engage the opponent$/ do
  Then  %{I should see "Engage opponent"}
end