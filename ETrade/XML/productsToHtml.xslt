<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">

      <xsl:text>Id, </xsl:text>
      <xsl:text>Name, </xsl:text>
      <xsl:text>Price, </xsl:text>
      <xsl:text>Category,</xsl:text>
      <xsl:text>Active,</xsl:text>
      <xsl:text>Description</xsl:text>
      <xsl:text>&#xa;</xsl:text>

      <!-- All elements  -->
      <xsl:for-each select="/Products/Product">
        <!--  attribute @ sign-->
        <xsl:value-of select="@Id"/>
        <xsl:text>, </xsl:text>
        <xsl:value-of select="Name"/>
        <xsl:text>, </xsl:text>
        <xsl:value-of select="Price"/>
        <xsl:text>, </xsl:text>
        <xsl:value-of select="Category"/>
        <xsl:text>, </xsl:text>
        <xsl:value-of select="Active"/>
        <xsl:text>, </xsl:text>
        <xsl:value-of select="Description"/>
        <xsl:text>&#xa;</xsl:text>
      </xsl:for-each>
    </xsl:template>
</xsl:stylesheet>
