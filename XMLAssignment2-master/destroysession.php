
<?php
session_start();

// //delete one session variable
// unset($_SESSION['password']);

//destroy all the session variable
// $_SESSION = [];

// //detroy seesion id
session_destroy();

?>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <title>SimpleXML</title>
  </head>
  <body>
    <div>
      <nav>
          <a href="ticket-list.php" >Ticket List</a>  |
          <a href="secure.php" >Secure</a>  |
          <a href="login.php" >Login</a>  |
          <a href="destroysession.php" >Logout</a>
      </nav>
    </div>
    <p>You have successfully been logged out!</p>
  </body>
</html>