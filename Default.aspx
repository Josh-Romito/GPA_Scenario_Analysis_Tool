<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="jumbotron">
        <h1>GPA TOOL</h1>
        <p class="lead">Enter your current known precentage grades below, and generate the mininmum 
            requirements to graduate for any courses outstanding!</p>
        <p></p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
       
        <div class="col-md-6 well">
            <div class="text-center">
                <h1>Semester 1.</h1>
                <hr />
                <label for="TextBox1"><h5>CS_007 </h5>
                    <asp:TextBox ID="TextBox1" class="form-control" runat="server"></asp:TextBox>
                </label>    
                <label for="TextBox2"><h5>CP_130</h5>
                    <asp:TextBox ID="TextBox2" class="form-control" runat="server"></asp:TextBox>
                </label>  
                <label for="TextBox3"><h5>CP_140</h5>
                    <asp:TextBox ID="TextBox3" class="form-control" runat="server"></asp:TextBox>
                </label>
                <label for="TextBox4"><h5>CP_150</h5>
                    <asp:TextBox ID="TextBox4" class="form-control" runat="server"></asp:TextBox>
                </label>
                <label for="TextBox5"><h5>CP_160</h5>
                    <asp:TextBox ID="TextBox5" class="form-control" runat="server"></asp:TextBox>
                </label>
                <label for="TextBox6"><h5>GE</h5>
                    <asp:TextBox ID="TextBox6" class="form-control" runat="server"></asp:TextBox>
                </label>
                <label for="TextBox7"><h5>GE</h5>
                    <asp:TextBox ID="TextBox7" class="form-control" runat="server"></asp:TextBox>
                </label>
            </div>
        </div>
        <div class="col-md-6 well">
            <div class="text-center">
                <h1>Semester 2.</h1><hr />
                <label for="TextBox8"><h5>CP_220</h5>
                    <asp:TextBox ID="TextBox8" class="form-control" runat="server"></asp:TextBox>
                </label>    
                <label for="TextBox9"><h5>CP_230</h5>
                    <asp:TextBox ID="TextBox9" class="form-control" runat="server"></asp:TextBox>
                </label>  
                <label for="TextBox10"><h5>CP_240</h5>
                    <asp:TextBox ID="TextBox10" class="form-control" runat="server"></asp:TextBox>
                </label>
                <label for="TextBox11"><h5>CP_250</h5>
                    <asp:TextBox ID="TextBox11" class="form-control" runat="server"></asp:TextBox>
                </label>
                <label for="TextBox12"><h5>CP_260</h5>
                    <asp:TextBox ID="TextBox12" class="form-control" runat="server"></asp:TextBox>
                </label>
                <label for="TextBox13"><h5>CP_219</h5>
                    <asp:TextBox ID="TextBox13" class="form-control" runat="server"></asp:TextBox>
                </label>
                <label for="TextBox14"><h5>MA_133</h5>
                    <asp:TextBox ID="TextBox14" class="form-control" runat="server"></asp:TextBox>
                </label>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12 well text-center">
            <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Calculate Minimum Precentage Grades" OnClick="Button1_Click" />
            <br />
            <hr />
            <asp:Button ID="Button2" runat="server" class="btn btn-primary" Text="Generate Combinations" OnClick="Button2_Click" />
        </div>
    </div>

    <div class="row">
        <div runat="server" ID="minOutput" class="col-md-6 well">
            <h3>Minimum required percentage grades to graduate: </h3><hr />
        </div>
        <div  runat="server" ID="comboOutput" class="col-md-6 well">
            <h3>Grade combination scenarios possible: </h3><br /><hr />
        </div>
    </div>
</asp:Content>
