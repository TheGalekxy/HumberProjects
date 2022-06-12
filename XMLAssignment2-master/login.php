<?php
// Login Credentials:
// TheGalekxy, test
// Vault, 12345
// CharCharBinks, password

session_start();
if(isset($_POST['login'])){
    //get values from form and assign to local variable
    $username = $_POST['username'];
    $inputedpass = $_POST['password'];

    //connect to XML and see if username and password matches
    $doc = new DOMDocument();

    //make sure the XML is nicely formatted
    $doc->preserveWhiteSpace = false;
    $doc->formatOutput = true;

    $doc->load("xml/users.xml");

    $users = $doc->getElementsByTagName("user");

    foreach ($users as $user) {
        $loginusername = $user->getElementsByTagName("username")->item(0)->nodeValue;
        $userid = $user->getElementsByTagName("id")->item(0)->nodeValue;
        $storedpass = $user->getElementsByTagName("password")->item(0)->nodeValue;
        $userrole = $user->attributes->getNamedItem("role")->nodeValue;

        if ($loginusername == $username && password_verify($inputedpass, $storedpass)) {
            $_SESSION['username'] = $username;
            $_SESSION['loggeduserid'] = $userid;
            if ($userrole == "admin") {
                $_SESSION['role'] = 'admin';
            } else {
                $_SESSION['role'] = 'client';
            }
            header('Location: ticket-list.php');
        } else {
            echo "Invalid credentials";
        }
    }
}
?>

<html lang="en">
    <head>
        <title>Update A List</title>
        <meta name="description" content="User Created Movie Lists">
        <meta name="keywords" content="Movie Lists">
        <!-- <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous"> -->
    </head>
    <body>
    <div>
        <div class="form-group">
            <div>
                <nav>
                    <a href="ticket-list.php" >Ticket List</a>  |
                    <a href="secure.php" >Secure</a>  |
                    <a href="login.php" >Login</a>  |
                    <a href="destroysession.php" >Logout</a>
                </nav>
            </div>
            <h2>Login form</h2>
            <form method="post" action="login.php">
                Username: <input type="text" name="username" /><br />
                Password: <input type="text" name="password" /><br />
                <input type="submit" name="login" value="Login" />
            </form>
        </div>
    </body>
</html>
