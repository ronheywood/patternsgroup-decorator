Decorator pattern

Give your objects new responsibilities
WITHOUT making any code changes to the underlysing classes

=> How to use instance variables?
	bool value for each condiment => call cost on the super to computes additional cost of condiments, 
	and then add the cost for each sub class
		- simples? "how would we implement change in the future? New condiments need booleans"
			* Price changes for condiments force change on existing code
			* New condiment new methods
			* new bevirages - condiments may not apply
			* double condiment orders?
			* Discounts on condiments?
			* Variations on condiments would be new condiments? (Low fat syrup?)
			* can't have some combinations of condiments?
			* Changing in existing code is an opening for bugs / unintended consequences (Open/Closed)

GIVEN a bevarage superclass
AND a set of sub classes: DarkRoast with cost 350 formatted as £3.50
When I want to order a variant Mocha with cost 25 formatted as £0.25
And I want Whipped Cream with cost 100 formatted as £1.00
Then the cost should be <double cost> 475 formatted as £4.75

Mocha : Beverage
+ cost (darkRoast.cost())

Whip : Bevarage
+ cost (mocha.cost())

Decorator has the same supertype as the objects they decorate
Multiple decorators cascade up to the super class
Decorator adds its own behaviour eitehr before OR after delegating
Objects can be decorated at run time - so we can add as many as we like