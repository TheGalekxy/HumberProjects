<?php
    // Checkign to see if the updateList button is set? From list???? 
    if(isset($_POST['submit'])){
        // retrieving the id of the list to be updated
        $id= $_POST['songid'];
        $artist= $_POST['artist'];
        
        // $test = '';
        // var_dump($id);
        // var_dump($artist);
    }
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="style.css">
    <title>Document</title>
</head>
<body>
    <a href="./index.php" id="backbutton" class="button">Back</a>
    <h1>Lyric Generator</h1>
    <h2>Lyrics of <span class="span"> <?= $id ?> </span> By <span class="span"> <?= $artist ?> </span></h2>
    <div class="container">
        <p class="output">

        </p>
    </div>
    <script type="text/javascript" src="api-methods.js"></script>
    <script type="text/javascript" src="script.js"></script>
    <script>getMusicMatchTrack("<?= $artist ?>", "<?= $id ?>");</script>
</body>
</html>