<?php

session_start();

$rows = '';

$doc = new DOMDocument();

//make sure the XML is nicely formatted
$doc->preserveWhiteSpace = false;
$doc->formatOutput = true;

$doc->load("xml/tickets.xml");

$tickets = $doc->getElementsByTagName("ticket");

if(!isset($_SESSION['username'])){
    header('Location: login.php');
}

if($_SESSION['role'] == 'admin'){
  // header('Location: user-list.php');

  foreach ($tickets as $ticket) {
      $rows .= '<tr>';
      $rows .= '<td>'."<p>".$ticket->getElementsByTagName("ticketid")->item(0)->nodeValue."</p>".'</td>';
      $rows .= '<td>'."<p>".$ticket->getElementsByTagName("userid")->item(0)->nodeValue."</p>".'</td>';
      $rows .= '<td>'."<p>".$ticket->getElementsByTagName("datetimeissued")->item(0)->nodeValue."</p>".'</td>';
      $rows .= '<td>'."<p>".$ticket->getElementsByTagName("subject")->item(0)->nodeValue."</p>".'</td>';
      $rows .= '<td>'."<p>".$ticket->getElementsByTagName("status")->item(0)->nodeValue."</p>".'</td>';
      $rows .= '<td>'."<form action='./ticket-details.php' method='post'>"."<input type='hidden' name='ticketId' value='".$ticket->getElementsByTagName("ticketid")->item(0)->nodeValue."'/>"."<input type='submit' name='ticketDetails' value='Details'/> </form>".'</td>';
      $rows .= '</tr>';
    }

}

if($_SESSION['role'] == 'client'){

  foreach ($tickets as $ticket) {
    if ($_SESSION['loggeduserid'] == $ticket->getElementsByTagName("userid")->item(0)->nodeValue) {
      $rows .= '<tr>';
      $rows .= '<td>'."<p>".$ticket->getElementsByTagName("ticketid")->item(0)->nodeValue."</p>".'</td>';
      $rows .= '<td>'."<p>".$ticket->getElementsByTagName("userid")->item(0)->nodeValue."</p>".'</td>';
      $rows .= '<td>'."<p>".$ticket->getElementsByTagName("datetimeissued")->item(0)->nodeValue."</p>".'</td>';
      $rows .= '<td>'."<p>".$ticket->getElementsByTagName("subject")->item(0)->nodeValue."</p>".'</td>';
      $rows .= '<td>'."<p>".$ticket->getElementsByTagName("status")->item(0)->nodeValue."</p>".'</td>';
      $rows .= '<td>'."<form action='./ticket-details.php' method='post'>"."<input type='hidden' name='ticketId' value='".$ticket->getElementsByTagName("ticketid")->item(0)->nodeValue."'/>"."<input type='submit' name='ticketDetails' value='Details'/> </form>".'</td>';
      $rows .= '</tr>';
    }
  }

}

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
    <table>
      <thead>
        <tr>
          <th>Ticket ID</th>
          <th>User ID</th>
          <th>Date & Time Issued</th>
          <th>Ticket Title</th>
          <th>Ticket Status</th>
          <th>Ticket Details</th>
        </tr>
      </thead>
      <tbody>
        <?php print $rows; ?>
      </tbody>
    </table>
  </body>
</html>