document.addEventListener("DOMContentLoaded", () => {
    const form = document.getElementById("auth-form");
    const formTitle = document.getElementById("form-title");
    const toggleLink = document.getElementById("toggle-link");
    const message = document.getElementById("message");

    let isSignUp = true;
    const users = {}; 

    toggleLink.addEventListener("click", () => {
        isSignUp = !isSignUp;
        formTitle.textContent = isSignUp ? "Sign Up" : "Login";
        form.querySelector("button").textContent = isSignUp ? "Sign Up" : "Login";
        toggleLink.textContent = isSignUp
            ? "Already have an account? Login"
            : "Don't have an account? Sign Up";
        message.textContent = ""; 
    });

    form.addEventListener("submit", (event) => {
        event.preventDefault();

        const username = document.getElementById("username").value;
        const password = document.getElementById("password").value;

        if (username === "" || password === "") {
            message.textContent = "Please fill in both fields.";
            return;
        }

        if (isSignUp) {
            if (users[username]) {
                message.textContent = "User already exists. Please login.";
            } else {
                users[username] = password; 
                message.textContent = "Sign Up successful! You can now login.";
                form.reset(); 
            }
        } else {
            if (users[username] === password) {
                message.textContent = "Login successful!";
            } else {
                message.textContent = "Invalid username or password.";
            }
        }
    });
});
