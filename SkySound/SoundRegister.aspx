<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SoundRegister.aspx.cs" Inherits="SkySound.SoundRegister" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head>
<meta http-equiv="Content-Type" content="text/html;charset=utf-8" />

<link rel="stylesheet" type="text/css" href="images/style.css" />
<title>天籁网站-Sounds of Nature</title>
</head>
<body>
<form id="form1" runat=server>
	<div id="bg">
		<div id="sadrzaj">
			<div id="zaglavlje">
			
				<div id="title">
					<a href="#">Sounds of Nature</a> 
				</div>				
				
					搜索: <asp:DropDownList ID="DropDownList" runat="server">
                   <asp:ListItem Value="category">类别</asp:ListItem>
                    <asp:ListItem Value="name">名称</asp:ListItem> </asp:DropDownList>
               <asp:TextBox ID="TBSearch" runat="server"></asp:TextBox>
                <asp:Button ID="BSearch" runat="server" Text="搜索" onclick="BSearch_Click" />
			</div>

			<div id="navigacija">
				<ul>
					<li><a href="Default.aspx">网站主页</a></li>
					<li><a href="SoundAbout.aspx">关于天籁</a></li>
					<li><a href="SoundSongList.aspx">天籁乐库</a></li>
					<li><a href="SoundRegister.aspx">会员注册</a></li>
					<li><a href="SoundAdmin/Login.aspx">后台管理</a></li>
				</ul>
	
				<div class="lijevo">
					<h3>最新用户</h3>
					<asp:Repeater ID="Repeater1" runat="server">
                     <ItemTemplate>                                
                                <%# Eval("name")%> &nbsp;&nbsp;                           
                               
                                
                        </ItemTemplate>
                        </asp:Repeater>
					
					
				</div>
			</div>

			<div id="pic">
			
					
			</div>

			

			<div class="lijeva_rubrika">
			<h3>用户注册</h3>
				<table cellpadding="0" cellspacing="0" style="width: 115%">
                    <tr>
                        <td><p class="login_p">&nbsp;&nbsp;&nbsp;用户名：<asp:TextBox CssClass="loginTb" ID="TBName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入用户名！" Text="*" ControlToValidate="TBName"></asp:RequiredFieldValidator></p>
                <p class="login_p">输入密码：<asp:TextBox CssClass="loginTb" TextMode="Password" ID="TPWD" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="请输入密码！" Text="*" ControlToValidate="TPWD"></asp:RequiredFieldValidator></p>
                <p class="login_p">确认密码：<asp:TextBox CssClass="loginTb" TextMode="Password" ID="TPWDS" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请再次输入密码！" Text="*" ControlToValidate="TPWDS"></asp:RequiredFieldValidator></p>
                <p class="login_p">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;昵称：<asp:TextBox CssClass="loginTb" ID="TBUserId" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="请输入昵称！" Text="*" ControlToValidate="TBUserId"></asp:RequiredFieldValidator></p>
                <p class="login_ps"><span>&nbsp;&nbsp; 验证码：<asp:TextBox ID="TVitorD" CssClass="loginTb" runat="server"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="请输入验证码！" Text="*" ControlToValidate="TVitorD"></asp:RequiredFieldValidator>
                </span><img class="login_image" src="SoundAdmin/ValidatImg.aspx" alt="验证码，如果不显示数字请刷新页面" />
                </p>
                <p class="login_p"><asp:Button ID="BRegister" runat="server" Text="注册" 
                        Height="30px" Width="77px" onclick="BRegister_Click" /></p></td>
                        
                    </tr>
                                           
                    </table>
			</div>
			<div id="downbox">
		 
			</div>
			
			<div id="footer">
			    Copyright © 2011 Designed by 类菌体</div>
		</div>
	</div>
    </form>
</body>
</html>
