function login(usernames) {
    let correctUsername = usernames[0];
    let loginAttempts = 0;
    while (loginAttempts < 4) {
        let usernameInput = usernames[loginAttempts + 1].split('').reverse().join('');
        if (usernameInput === correctUsername) {
            console.log(`User ${correctUsername} logged in.`);
            return;
        }

        loginAttempts++;
        if (loginAttempts < 4) {
            console.log('Incorrect password. Try again.');
        }
    }

    console.log(`User ${correctUsername} blocked!`);
}