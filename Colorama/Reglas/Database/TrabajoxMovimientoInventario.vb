﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.42
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports Infoware.Reglas

#Region "TrabajoxMovimientoInventario"
Partial Public Class TrabajoxMovimientoInventario
  Inherits _Database

  Private mEmpres_Codigo As Integer = 0

  Private mSucurs_Codigo As Integer = 0

  Private mTrabaj_Secuencia As Integer = 0

  Private mParame_Tipomovinv As Integer = 0

  Private mPardet_Tipomovinv As Integer = 0

  Private mMovinv_Secuencia As Integer = 0

  Public Sub New()
    MyBase.New()
  End Sub

  <XmlAttribute()> _
  Public Overridable Property Empres_Codigo() As Integer
    Get
      Return Me.mEmpres_Codigo
    End Get
    Set(ByVal value As Integer)
      Me.mEmpres_Codigo = value
      EsModificado = True
    End Set
  End Property

  <XmlAttribute()> _
  Public Overridable Property Sucurs_Codigo() As Integer
    Get
      Return Me.mSucurs_Codigo
    End Get
    Set(ByVal value As Integer)
      Me.mSucurs_Codigo = value
      EsModificado = True
    End Set
  End Property

  <XmlAttribute()> _
  Public Overridable Property Trabaj_Secuencia() As Integer
    Get
      Return Me.mTrabaj_Secuencia
    End Get
    Set(ByVal value As Integer)
      Me.mTrabaj_Secuencia = value
      EsModificado = True
    End Set
  End Property

  <XmlAttribute()> _
  Public Overridable Property Parame_Tipomovinv() As Integer
    Get
      Return Me.mParame_Tipomovinv
    End Get
    Set(ByVal value As Integer)
      Me.mParame_Tipomovinv = value
      EsModificado = True
    End Set
  End Property

  <XmlAttribute()> _
  Public Overridable Property Pardet_Tipomovinv() As Integer
    Get
      Return Me.mPardet_Tipomovinv
    End Get
    Set(ByVal value As Integer)
      Me.mPardet_Tipomovinv = value
      EsModificado = True
    End Set
  End Property

  <XmlAttribute()> _
  Public Overridable Property Movinv_Secuencia() As Integer
    Get
      Return Me.mMovinv_Secuencia
    End Get
    Set(ByVal value As Integer)
      Me.mMovinv_Secuencia = value
      EsModificado = True
    End Set
  End Property
End Class
#End Region
