select round (7.53694,2)
select round (7.53494,2)
--round (expr, nr cifre, [tip rotunjire]) 
--tip rotunjire 0 este rotunjire propiu-zisa !=0 este tunchere
select round ((7.0+8.0+8.0)/3,2,1)
select round (8352798,-2, 1)
select rand ()
select round (rand ()*100, 0)
select round (rand ()*200-100, 0)
select ascii ('A')
select char (172)
select len ('abcd') 
select lower ('abcXYZ1234')
select upper ('abcXYZ1234')
select left ('abcdfbgh',3)
select right ('abcdfbgh', 3)
select substring ('abcdefh', 3, 2)
select charindex ('bc', 'abcdabcdabcd')
select charindex ('bc', 'abcdabcdabcd', 3)
select charindex ('bc', 'abcdabcdabcd', 7)
select charindex ('bc', 'abcdabcdabcd', 11)
select charindex ('bc', 'abcdabcdabcd', 15)
select 'abc' + 'xyz'
select '|' + ltrim ('       Pitesti       ')+'|'
select '|' + rtrim ('       Pitesti       ')+'|'
select '|' + ltrim(rtrim ('       Pitesti       '))+'|'
select replace ('abcdabcdabcd', 'bc', 'xyz')
select stuff ('mere', 1,2, 'mu')
select stuff ('informatica', 11, 1, 'ian')
select replicate ('*', 8)