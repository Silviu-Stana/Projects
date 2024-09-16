function abbrevName(name){
        name = name.split(' ');
        
        return name[0].substring(0,1).toUpperCase() + '.' + name[1].substring(0,1).toUpperCase();
    }


console.log(abbrevName('Sam Harris'));