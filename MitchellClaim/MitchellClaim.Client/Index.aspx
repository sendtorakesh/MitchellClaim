<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="MitchellClaim.Client.Index" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript">
        $(document).ready
            (
            function () {
                jQuery.support.cors = true;
                $('#btnGetClaims').click(
                    function () {

                        $.ajax
                            (
                                {
                                    url: 'http://localhost:50072/api/mitchellclaim',
                                    type: 'GET',
                                    datatype: 'xml',
                                    success: function (data) {
                                        $('#lblResult').append($('<div>').text(JSON.stringify(data)));
                                        
                                    }

                                }
                            );
                    }
                );

                $('#btnGetClaimbyClaimNumber').click(
                    function () {
                        var claimNumber = $('#txtClaimNumber').val();
                        if (claimNumber = ' ') {
                            alert('Please provide claim number.');
                            return;
                        }
                        var serviceUrl = 'http://localhost:50072/api/mitchellclaim/' + claimNumber;
                        $.ajax
                            (
                                {
                                    url: serviceUrl,
                                    type: 'GET',
                                    datatype: 'xml',
                                    success: function (data) {
                                        $('#lblResult').append($('<div>').text(JSON.stringify(data)));

                                    }

                                }
                            );
                    }
                );
            }
            );
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Mitchell Claim Web Client : -</h1><h3>Service url : http://localhost:50072/api/mitchellclaim</h3>
        <br />
        <h2>Service call To get all the claims</h2>
           <input type="button" id="btnGetClaims" value="Get Claims" />
        <br />
        <br />
        <hr />
        <br />
        <h2>Service call to save claim</h2>
       <label>Input Claim XML is located under below location : -</label><br /> 
        <asp:Label ID="lblxmlLocation1" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnAddClaim" runat ="server" Text="Submit Claim" OnClick="btnAddClaim_Click" />
        <br />
        <br />
        <hr />
        <br />
        <h2>Service call to get claim by claim number</h2>
        <asp:TextBox ID="txtClaimNumber" runat="server"></asp:TextBox>
        <br />
        <br />
         <input type="button" id="btnGetClaimbyClaimNumber" value="Get Claim By Claim Number" />
        <h2>Result : -</h2> 
        <div id="lblResult"></div>
    </div>
    </form>
</body>
</html>
