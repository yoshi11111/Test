<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    <script src="https://cdn.jsdelivr.net/npm/vue"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js">
    <script src="https://unpkg.com/axios/dist/axios.min.js"></script>
    <script src="Scripts/Common/common.js"></script>
</head>
<body>

<div id="app">
 <h2>TEST</h2>
</div>
    <script type="text/javascript">
      
        new Vue({
            el: '#app',
            data: {
              
                count: 100
            },
            components: {
                'denshosha': denshosha
            },
            methods: {
                tohyo: functi
            }
        })
       
    </script>
</body>
</html>
