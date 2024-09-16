function century(year) {
  
        
        if (year%100===0)
                {
                        if(year>100)
                {
                        let digitCount = year.toString().length;
                        return parseInt(year.toString().substring(0,digitCount-2));         
                }
            else return 0;
          }
        else
          {
            if(year>100)
                {
                        let digitCount = year.toString().length;
                        return parseInt(year.toString().substring(0,digitCount-2))+1;        
                }
            else return 1;
          }
      }

console.log(century(1705))