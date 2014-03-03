<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addSoundSong.aspx.cs" Inherits="SkySound.SoundAdmin.addSoundSong" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head>
<meta http-equiv="Content-Type" content="text/html;charset=utf-8" />

<link rel="stylesheet" type="text/css" href="../images/style.css" />
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
					<li><a href="../Default.aspx">网站主页</a></li>
					<li><a href="../SoundAbout.aspx">关于天籁</a></li>
					<li><a href="#">天籁乐库</a></li>
					<li><a href="../SoundRegister.aspx">会员注册</a></li>
					<li><a href="Login.aspx">后台管理</a></li>
				</ul>
	
				<div class="lijevo">
					<h3>会员信息</h3>
					<table style="width: 127px">
                      <tr>
                           <td><asp:Label ID="LBName" runat="server" Text="Label">用户名：</asp:Label></td>
                           <td><asp:Label ID="LBNames" runat="server" Text="Label"></asp:Label></td>
                     </tr> 
                     <tr>
                           <td><asp:Label ID="LBUserId" runat="server" Text="Label">昵称：</asp:Label></td>
                           <td><asp:Label ID="LBUserIds" runat="server" Text="Label"></asp:Label></td>
                     </tr> 
                     <tr>
                           <td><asp:Label ID="LBCreateTime" runat="server" Text="Label">创建时间：</asp:Label></td>
                           <td><asp:Label ID="LBCreateTimes" runat="server" Text="Label"></asp:Label></td>
                     </tr>                           
                    </table>
					<div id="infobox">
					   <ul>                           
                            <li><a href="SoundmanageSong.aspx">歌曲管理</a></li>
                            <li><a href="SoundaddSong.aspx">上传歌曲</a></li>
                            <li><a href="SounduserManage.aspx">账号管理</a></li>   
                          
                       </ul>   
					</div>
				</div>
			</div>

			<div id="pic">
			
					
			</div>

			

			<div class="lijeva_rubrika">
			<h3>声音管理</h3>
				<table cellpadding="0" cellspacing="0" style="width: 115%">
                    <tr>
                        <td>
                            <p>
                                <asp:Label ID="Label2" runat="server" Text="Label">请输入上传声音名</asp:Label>
                            
                           
                                <asp:TextBox ID="TBUpName" runat="server" CssClass="upTB"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="TBUpName" ErrorMessage="请输入声音名称！" Text="*"></asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="Label3" runat="server" Text="Label">请输入上传声音类别</asp:Label>
                            
                           
                                <asp:TextBox ID="TBUpCategory" runat="server" CssClass="upTB"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="TBUpName" ErrorMessage="请输入声音类别！" Text="*"></asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="Label4" runat="server" Text="Label">请输入上传声音作者</asp:Label>
                           
                                <asp:TextBox ID="TBUpSonger" runat="server" CssClass="upTB"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="TBUpName" ErrorMessage="请输入声音作者！" Text="*"></asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="Label1" runat="server" Text="Label">请选择上传文件</asp:Label>
                            
                                <asp:FileUpload ID="FileUpload" runat="server" />
                                <asp:Button ID="upButton" runat="server" onclick="upButton_Click" Text="上传" />
                            </p>
                        </td>
                        
                    </tr>
                                           
                    </table>
			</div>
			
			
			<div id="footer">
			    Copyright © 2011 Designed by 类菌体</div>
		</div>
	</div>
    </form>
</body>
</html>
