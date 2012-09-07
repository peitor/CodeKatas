describe("StringCalculator", function () {  

    describe("add", function () {  
		it("returns 0 when passed empty string", function () {  
			expect(add("")).toEqual(0);  
		});  

		it("returns 0 when passed undefined", function () {  
			expect(add(undefined)).toEqual(0);  
		});  
		
		it("returns 0 when passed null", function () {  
			expect(add(null)).toEqual(0);  
		}); 
		
		it("returns 0 when passed NOTHING", function () {  
			expect(add()).toEqual(0);  
		}); 
		
		it("returns 1 when passed in 1 ", function () {  
			expect(add("1")).toEqual(1);
		});  
		
		it("returns the sum when passed in 2 numbers ", function () {  
			expect(add("1,2")).toEqual(3);
		}); 
		
		it("returns the sum when passed in multiple numbers ", function () {  
			expect(add("1,2,3,4,5,6,7,8,9,10")).toEqual(55);
		});
		
		it("handles newlines as delimiter ", function () {  
			expect(add("1\n2")).toEqual(3);
		});	
		
		it("allows changing the delimiter ", function () {  
			expect(add("//;\n1;2")).toEqual(3);
		});	

		it("throws an exception if input consists of negatives", function () {  
			expect( function(){add("1,-2");} ).toThrow();
		});			
	});  
});  


function add(input) 
{  
	if (input === "")
		return 0;
	if (!input)
		return 0;
	
	var delimiter = ",";
		
	if (input.length > 3 
		&& input[0] === '/'
		&& input[1] === '/'
		&& input[3] === '\n') 
	{
		delimiter = input[2];
		input = input.substring(4);
	}
	
	input = input.replace("\n",delimiter);
	
	var arrayString = input.split(delimiter);
	
	var sum = 0;
	for (i = 0; i < arrayString.length; i++)
	{
		var singleNumber = parseInt(arrayString[i]);
		if (singleNumber <0)
		{
			throw "no negatives allowed";
		}
		
		sum += singleNumber; 
	}

	return sum;
}


