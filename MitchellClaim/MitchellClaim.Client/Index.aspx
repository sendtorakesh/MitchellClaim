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
                                        $.each
                                            (
                                                data,
                                                function (key, MitchellClaimType) {
                                                    $('#lblResult').append('<br><br>');
                                                    $('#lblResult').append('claimNumberField:' + MitchellClaimType.claimNumberField + '<br>');
                                                    $('#lblResult').append('claimantFirstNameField:' + MitchellClaimType.claimantFirstNameField + '<br>');
                                                    $('#lblResult').append('claimantLastNameField:' + MitchellClaimType.claimantLastNameField + '<br>');
                                                    $('#lblResult').append('statusField:' + MitchellClaimType.statusField + '<br>');
                                                    $('#lblResult').append('statusFieldSpecified:' + MitchellClaimType.statusFieldSpecified + '<br>');
                                                    $('#lblResult').append('lossDateField:' + MitchellClaimType.lossDateField + '<br>');
                                                    $('#lblResult').append('lossDateFieldSpecified:' + MitchellClaimType.lossDateFieldSpecified + '<br>');
                                                    $('#lblResult').append('lossInfoField:' + MitchellClaimType.lossInfoField + '<br>');
                                                    $('#lblResult').append('assignedAdjusterIDField:' + MitchellClaimType.assignedAdjusterIDField + '<br>');
                                                    $('#lblResult').append('assignedAdjusterIDFieldSpecified:' + MitchellClaimType.assignedAdjusterIDFieldSpecified + '<br>');
                                                    $('#lblResult').append('vehiclesField:' + MitchellClaimType.claimantFirstNameField);
                                                }
                                            );
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
                                        $('#lblResult').empty();
                                        $('#lblResult').append('<br><br>');
                                        $('#lblResult').append('claimNumberField:' + data.claimNumberField + '<br>');
                                        $('#lblResult').append('claimantFirstNameField:' + data.claimantFirstNameField + '<br>');
                                        $('#lblResult').append('claimantLastNameField:' + data.claimantLastNameField + '<br>');
                                        $('#lblResult').append('statusField:' + data.statusField + '<br>');
                                        $('#lblResult').append('statusFieldSpecified:' + data.statusFieldSpecified + '<br>');
                                        $('#lblResult').append('lossDateField:' + data.lossDateField + '<br>');
                                        $('#lblResult').append('lossDateFieldSpecified:' + data.lossDateFieldSpecified + '<br>');
                                        $('#lblResult').append('lossInfoField:' + data.lossInfoField + '<br>');
                                        $('#lblResult').append('assignedAdjusterIDField:' + data.assignedAdjusterIDField + '<br>');
                                        $('#lblResult').append('assignedAdjusterIDFieldSpecified:' + data.assignedAdjusterIDFieldSpecified + '<br>');
                                        $('#lblResult').append('vehiclesField:' + data.claimantFirstNameField);

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
        <h1>Mitchell Claim Web Client : -</h1>
           <input type="button" id="btnGetClaims" value="Get Claims" />
        <br />
        <br />
        <hr />
        <br />
        <asp:FileUpload ID="btnUpload" runat ="server" />
        <asp:Label ID="lblFileNotFound" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnAddClaim" runat ="server" Text="Submit Claim" OnClick="btnAddClaim_Click" />
        <br />
        <br />
        <hr />
        <br />
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
