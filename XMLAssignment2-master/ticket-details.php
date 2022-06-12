<?php
    session_start();

    date_default_timezone_set('EST');
    $doc = new DOMDocument();

    //make sure the XML is nicely formatted
    $doc->preserveWhiteSpace = false;
    $doc->formatOutput = true;

    $doc->load("xml/tickets.xml");

    $tickets = $doc->getElementsByTagName("ticket");
    // var_dump($tickets->item(0));
    // var_dump($tickets->length);

    $rows = '';
    $allMessages = '';

    $title="";
    $addMessage="";


    if(isset($_POST['ticketDetails'])){
        // retrieving the id of the ticket to be updated
        $ticketNumber = $_POST['ticketId'];
        // $_SESSION['ticketid'] = $ticketNumber;
        // echo($ticketNumber);
        // print_r($id);
        // var_dump("test".$id);
    }

    // Checking to see if the updCar button is set
    if(isset($_POST['addMessage'])){
        // Selecting the values of the form
        $id= $_POST['test'];
        $newChat = $_POST['message'];

        // checking if count is set
        if($newChat){
            createMessage($newChat, $id, $_SESSION['loggeduserid']);
            header('Location: ticket-list.php');
            // header("Refresh:0");
        } else {
            echo "problem";
        }
    }

    // var_dump($tickets->length);

    foreach ($tickets as $ticket) {
        if ($ticket->getElementsByTagName("ticketid")->item(0)->nodeValue == $ticketNumber) {

            $rows .= '<tr>';
            $rows .= '<td>'."<p>".$ticket->getElementsByTagName("ticketid")->item(0)->nodeValue."</p>".'</td>';
            $rows .= '<td>'."<p>".$ticket->getElementsByTagName("userid")->item(0)->nodeValue."</p>".'</td>';
            $rows .= '<td>'."<p>".$ticket->getElementsByTagName("datetimeissued")->item(0)->nodeValue."</p>".'</td>';
            $rows .= '<td>'."<p>".$ticket->getElementsByTagName("subject")->item(0)->nodeValue."</p>".'</td>';
            $rows .= '<td>'."<p>".$ticket->getElementsByTagName("status")->item(0)->nodeValue."</p>".'</td>';
            $rows .= '</tr>';

            // echo($ticket);
            // print_r((string) $ticket->messages->message->content);

            $messages = $ticket->getElementsByTagName("messages")[0]->childNodes;
            // var_dump($test->childNodes);

            foreach ($messages as $message) {
                // var_dump($key->nodeValue);
                $allMessages .= "<p>".(string)$message->childNodes->item(0)->nodeValue."</p>";
                $allMessages .= "<p>".(string)$message->childNodes->item(1)->nodeValue."</p>";
                $allMessages .= "<p>".(string)$message->childNodes->item(2)->nodeValue."</p>";
            };

            break;
        }
      }

    //   $senderId
      function createMessage($content, $ticketId, $loggedInUserId) {
        global $doc;
        //creating a new message
        $newmessage = $doc->createElement("message");
        // $newperson->setAttribute("job", "janitor");

        $date = $doc->createElement("datetime", date("Y-m-d H:i:s"));
        $content = $doc->createElement("content", $content);
        $sender = $doc->createElement("senderId", $loggedInUserId);

        $newmessage->appendChild($date);
        $newmessage->appendChild($content);
        $newmessage->appendChild($sender); //append <name> in <person>

        var_dump($doc->documentElement->childNodes->item(0)->childNodes->item(5));

        $doc->documentElement->childNodes->item($ticketId-1)->childNodes->item(5)->appendChild($newmessage);
        $doc->save("xml/tickets.xml");

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
    <div class="form-group">
        <table>
          <thead>
            <tr>
              <th>Ticket ID</th>
              <th>User ID</th>
              <th>Date & Time Issued</th>
              <th>Ticket Title</th>
              <th>Ticket Status</th>
            </tr>
          </thead>
          <tbody>
            <?php print $rows; ?>
          </tbody>
        </table>

        <p><?php print $allMessages; ?></p>

        <!--    Form to Add Message -->
        <form action="" method="post">
            <input type="hidden" name="test" value="<?= $ticketNumber; ?>" />
            <div class="form-group">
                <label for="message">Submit a Message :</label>
                <input type="text" value="<?= $title; ?>" class="form-control" name="message" id="message">
                    
                
                <span style="color: red">

                </span>
            </div>
            <a href="./ticket-list.php" id="btn_back" class="btn btn-success float-left">Back</a>
            <button type="submit" name="addMessage"
                    class="btn btn-primary float-right" id="btn-submit">
                Submit Message
            </button>
        </form>
    </div>
  </body>
</html>