<?php 
    $file_name = $_GET['file'];
    $file_url = 'bare_files/' . $file_name;
    header('Content-Type: application/octet-stream');
    header("Content-Transfer-Encoding: Binary"); 
    header("Content-disposition: attachment; filename=\"".$file_name."\""); 
    readfile($file_url);
?>
