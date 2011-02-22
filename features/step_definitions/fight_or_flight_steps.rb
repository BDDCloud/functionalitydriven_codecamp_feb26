Given /^the ninja has ([^"]*)$/ do |skill|
	#Given %{I select "#{skill}" from "ninja_skill"}
	When "I fill in the following:"
		%{"| ninja_skill | #{skill}       |"}

end