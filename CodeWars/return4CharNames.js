//my solution
function friend(friends) {
        let friendsList = []
        friends.forEach((friend) => {
                if (friend.length === 4) friendsList.push(friend)
        })

        return friendsList
}

console.log(friend(['Jimm', 'Cari', 'aret', 'truehdnviegkwgvke', 'sixtyiscooooool'])) //["Jimm", "Cari", "aret"]

//optimal function
function friend2(friends) {
        return friends.filter((n) => n.length === 4)
}
