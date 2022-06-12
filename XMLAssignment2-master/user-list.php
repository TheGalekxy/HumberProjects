<?php
$rows = '';
$formDetails = '';
$xml = simplexml_load_file("xml/users.xml");

// $dom = dom_import_simplexml($xml)->ownerDocument;
// $dom->preserveWhiteSpace = false;
// $dom->formatOutput = true;
// $dom->save("xml/tickets.xml");


foreach ($xml->children() as $user) {
    $rows .= '<tr>';
    // $rows .= '<td>'.'<img src="'.$p->cover.'" alt="'.$p->title.' book cover" height="150">'.'</td>';
    $rows .= '<td>'."<p>".$user->id."</p>".'</td>';
    $rows .= '<td>'."<p>".$user->username."</p>".'</td>';
    $rows .= '<td>'."<p>".$user->password."</p>".'</td>';
    $rows .= '<td>'."<p>".$user->email."</p>".'</td>';
    // $rows .= '<td>'."<p>".$user->status."</p>".'</td>';
    $rows .= '<td>'."<form action='./user-details.php' method='post'>"."<input type='hidden' name='userId' value='".$user->id."'/>"."<input type='submit' name='userDetails' value='Details'/> </form>".'</td>';
    // $rows .= '<td>'.'<a href="book.php?id='.$p->id.'">'.$p->title.'</a><br>'.$p->author->lastname.', '.$p->author->firstname.' '.$p->author->middlename.'</td>';
    $rows .= '</tr>';
  }

?>
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <title>SimpleXML</title>
  </head>
  <body>
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