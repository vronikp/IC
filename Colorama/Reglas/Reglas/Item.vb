'------------------------------------------------------------------------------
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

Imports Infoware.Datos
Imports Infoware.Reglas.General

Imports System.IO
Imports System.ComponentModel

#Region "Item"
Public Class Item

  Const _Procedimiento As String = "proc_Item"

  Private mPardetGrupo As WWTSParametroDet = Nothing

  Private mPardetMarca As WWTSParametroDet = Nothing

  Private mPardetMedida As WWTSParametroDet = Nothing

  Private mPardetTipoInventario As WWTSParametroDet = Nothing

  Private mPardetUnidadMedida As WWTSParametroDet = Nothing

  Private mItem_Imagen As System.Drawing.Image = Nothing

  Private mProveedor As Proveedor = Nothing

  Private mCambio_Imagen As Boolean = False

  Public Sub New(ByVal _OperadorDatos As OperadorDatos, ByVal _EsNuevo As Boolean)
    MyBase.New()
    OperadorDatos = _OperadorDatos
    EsNuevo = _EsNuevo
  End Sub

  Public Sub New(ByVal _OperadorDatos As OperadorDatos, ByVal _Item_Codigo As Integer)
    Me.New(_OperadorDatos, False)
    Item_Codigo = _Item_Codigo
    If Not Me.Recargar Then
      Throw New Exception(OperadorDatos.MsgError)
    End If
  End Sub

  Private mCantidad As Decimal = 0
  Public Property Cantidad As Decimal
    Get
      Return mCantidad
    End Get
    Set(value As Decimal)
      mCantidad = value
    End Set
  End Property

  'WWTSParametroDet
  Public Overridable Property PardetGrupo() As WWTSParametroDet
    Get
      If Me.mPardetGrupo Is Nothing AndAlso Pardet_Grupo > 0 Then
        Me.mPardetGrupo = New WWTSParametroDet(OperadorDatos, Parame_Grupo, Pardet_Grupo)
      End If
      Return Me.mPardetGrupo
    End Get
    Set(ByVal value As WWTSParametroDet)
      Me.mPardetGrupo = value
      Parame_Grupo = value.Parame_Codigo
      Pardet_Grupo = value.Pardet_Secuencia
    End Set
  End Property

  'WWTSParametroDet
  Public Overridable Property PardetMarca() As WWTSParametroDet
    Get
      If Me.mPardetMarca Is Nothing AndAlso Pardet_Marca > 0 Then
        Me.mPardetMarca = New WWTSParametroDet(OperadorDatos, Parame_Marca, Pardet_Marca)
      End If
      Return Me.mPardetMarca
    End Get
    Set(ByVal value As WWTSParametroDet)
      Me.mPardetMarca = value
      If value Is Nothing Then
        Throw New Exception("Debe seleccionar una marca")
      End If
      Parame_Marca = value.Parame_Codigo
      Pardet_Marca = value.Pardet_Secuencia
    End Set
  End Property

  'Proveedor
  Public Overridable Property Proveedor() As Proveedor
    Get
      If Me.mProveedor Is Nothing AndAlso Entida_Proveedor > 0 Then
        Me.mProveedor = New Proveedor(OperadorDatos, Entida_Proveedor)
      End If
      Return Me.mProveedor
    End Get
    Set(ByVal value As Proveedor)
      Me.mProveedor = value
      If value Is Nothing Then
        Entida_Proveedor = 0
      Else
        Entida_Proveedor = value.Entida_Codigo
      End If
    End Set
  End Property

  'WWTSParametroDet
  Public Overridable Property PardetTipoInventario() As WWTSParametroDet
    Get
      If Me.mPardetTipoInventario Is Nothing AndAlso Pardet_Tipoinventario > 0 Then
        Me.mPardetTipoInventario = New WWTSParametroDet(OperadorDatos, Parame_Tipoinventario, Pardet_Tipoinventario)
      End If
      Return Me.mPardetTipoInventario
    End Get
    Set(ByVal value As WWTSParametroDet)
      Me.mPardetTipoInventario = value
      Parame_Tipoinventario = value.Parame_Codigo
      Pardet_Tipoinventario = value.Pardet_Secuencia
    End Set
  End Property

  'WWTSParametroDet
  Public Overridable Property PardetUnidadMedida() As WWTSParametroDet
    Get
      If Me.mPardetUnidadMedida Is Nothing AndAlso Pardet_Unidadmedida > 0 Then
        Me.mPardetUnidadMedida = New WWTSParametroDet(OperadorDatos, Parame_Unidadmedida, Pardet_Unidadmedida)
      End If
      Return Me.mPardetUnidadMedida
    End Get
    Set(ByVal value As WWTSParametroDet)
      Me.mPardetUnidadMedida = value
      Parame_Unidadmedida = value.Parame_Codigo
      Pardet_Unidadmedida = value.Pardet_Secuencia
    End Set
  End Property

  'Item_Imagen
  Public Overridable ReadOnly Property Item_ImagenStream() As Byte()
    Get
      Dim imagen() As Byte
      Dim Result As Object = Nothing
      Dim bReturn As Boolean = True
      OperadorDatos.AgregarParametro("@accion", "Pl")
      OperadorDatos.AgregarParametro("@Item_Codigo", Item_Codigo)
      OperadorDatos.Procedimiento = _Procedimiento
      bReturn = OperadorDatos.Ejecutar(Result)
      OperadorDatos.LimpiarParametros()
      Try
        imagen = CType(Result, Byte())
      Catch ex As System.Exception
        imagen = Nothing
      End Try
      Return imagen
    End Get
  End Property

  'Item_Imagen
  Public Overridable ReadOnly Property Item_Imagen(Optional ByVal heightwidth As Integer = 0) As System.Drawing.Image
    Get
      If mItem_Imagen Is Nothing Then
        Try
          Dim imagen() As Byte
          imagen = Item_ImagenStream
          Dim ms As New MemoryStream
          ms.Write(imagen, 0, imagen.GetUpperBound(0) + 1)
          mItem_Imagen = System.Drawing.Image.FromStream(ms)
          ms.Close()
        Catch ex As System.Exception
          mItem_Imagen = Nothing
        End Try
      End If
      If heightwidth > 0 AndAlso mItem_Imagen IsNot Nothing Then
        Dim imagenbm = New System.Drawing.Bitmap(mItem_Imagen)
        Return imagenbm.GetThumbnailImage(heightwidth, heightwidth, Nothing, New IntPtr())
      Else
        Return mItem_Imagen
      End If
    End Get
  End Property

  Private mArchivoImagen As String = String.Empty
  Public WriteOnly Property ArchivoImagen() As String
    Set(ByVal value As String)
      mArchivoImagen = value
      EsModificado = True
      mCambio_Imagen = True
    End Set
  End Property

  <Infoware.Reportes.CampoReporteAtributo("Grupo", Infoware.Reportes.CampoReporteAtributo.EnumTipoDato.Texto, 100, True)> _
  Public ReadOnly Property GrupoString() As String
    Get
      If PardetGrupo Is Nothing Then
        Return String.Empty
      Else
        Return mPardetGrupo.Pardet_Descripcion
      End If
    End Get
  End Property

  <Infoware.Reportes.CampoReporteAtributo("Marca", Infoware.Reportes.CampoReporteAtributo.EnumTipoDato.Texto, 100, True)> _
  Public ReadOnly Property MarcaString() As String
    Get
      If PardetMarca Is Nothing Then
        Return String.Empty
      Else
        Return mPardetMarca.Pardet_Descripcion
      End If
    End Get
  End Property

  <Infoware.Reportes.CampoReporteAtributo("Tipo Inventario", Infoware.Reportes.CampoReporteAtributo.EnumTipoDato.Texto, 100, True)> _
  Public ReadOnly Property TipoInventarioString() As String
    Get
      If PardetTipoInventario Is Nothing Then
        Return String.Empty
      Else
        Return mPardetTipoInventario.Pardet_Descripcion
      End If
    End Get
  End Property

  Public ReadOnly Property UnidadMedidaString() As String
    Get
      If PardetUnidadMedida Is Nothing Then
        Return String.Empty
      Else
        Return mPardetUnidadMedida.Pardet_Descripcion
      End If
    End Get
  End Property

  Public ReadOnly Property BuscarValor(ByVal _tipomovinv As Enumerados.enumTipoMovInv, ByVal _sucursal As Sucursal, ByVal _PardetTipoPrecio As WWTSParametroDet, ByVal _porciva As Decimal, ByVal _bodega As Bodega, ByVal _cantidad As Decimal) As Decimal
    Get
      Dim _valor As Decimal = 0
      Select Case _tipomovinv
        Case Enumerados.enumTipoMovInv.Venta, Enumerados.enumTipoMovInv.DevVenta
          If Item_PrecioxCantidad Then
            Dim _pxc As ItemPrecioxCantidad = ItemPrecioxCantidadList.ObtenerPrecioxCantidad(Me, _sucursal, _cantidad)
            If _pxc IsNot Nothing Then
              _valor = _pxc.ItPrCa_ValorUnitario
              If Item_esIvaIncluido Then
                _valor = _valor / (1 + _porciva / 100)
              End If
            End If
          Else
            Dim _ItemxTipoPrecio As ItemxTipoPrecio
            Try
              _ItemxTipoPrecio = New ItemxTipoPrecio(Me, _sucursal, _PardetTipoPrecio)
              _valor = _ItemxTipoPrecio.IteTip_Valor
              If Item_esIvaIncluido Then
                _valor = _valor / (1 + _porciva / 100)
              End If
            Catch ex As Exception
              _valor = 0
            End Try
          End If
        Case Else
          Try
            Dim _itemxbodega As New ItemxBodega(Me, _bodega)
            _valor = _itemxbodega.Itebod_Costopromedio
          Catch ex As Exception
            _valor = 0
          End Try
      End Select
      Return _valor
    End Get
  End Property

  'Private mItemxTipoPrecios As ItemxTipoPrecioList = Nothing
  Public ReadOnly Property ItemxTipoPrecios(ByVal _Sucursal As Sucursal) As ItemxTipoPrecioList
    Get
      'If mItemxTipoPrecios Is Nothing Then
      '  mItemxTipoPrecios = ItemxTipoPrecioList.ObtenerLista(Me, mSucursal)
      'End If
      'Return mItemxTipoPrecios
      If _Sucursal Is Nothing Then
        Return Nothing
      End If
      Return ItemxTipoPrecioList.ObtenerLista(Me, _Sucursal)
    End Get
  End Property

  'Private mItemxBodegas As ItemxBodegaList = Nothing
  Public ReadOnly Property ItemxBodegas(Optional ByVal _Sucursal As Sucursal = Nothing) As ItemxBodegaList
    Get
      'If mItemxBodegas Is Nothing Then
      '  mItemxBodegas = ItemxBodegaList.ObtenerLista(Me)
      'End If
      'Return mItemxBodegas
      If _Sucursal Is Nothing Then
        Return Nothing
      End If
      Return ItemxBodegaList.ObtenerLista(Me, _Sucursal)
    End Get
  End Property

#Region "Saldos bodega"
  Private mBodegas As BodegaList = Nothing
  Public ReadOnly Property Bodegas() As BodegaList
    Get
      If mBodegas Is Nothing Then
        mBodegas = BodegaList.ObtenerLista(OperadorDatos)
      End If
      Return mBodegas
    End Get
  End Property

  Public ReadOnly Property SaldoBodega(ByVal _Bodega As Bodega) As Decimal
    Get
      If Me.Item_Estangible Then
        Try
          Dim _ItemxBodega As New ItemxBodega(Me, _Bodega)
          Return _ItemxBodega.Itebod_Cantidad
        Catch ex As Exception
        End Try
      End If
      Return 0
    End Get
  End Property

  Public ReadOnly Property SaldoBodega(ByVal _NumBodega As Integer) As Decimal
    Get
      If Bodegas.Count >= _NumBodega Then
        Return SaldoBodega(mBodegas(_NumBodega))
      Else
        Return 0
      End If
    End Get
  End Property

  Public ReadOnly Property SaldoBodega1() As Decimal
    Get
      Return SaldoBodega(0)
    End Get
  End Property

  Public ReadOnly Property SaldoBodega2() As Decimal
    Get
      Return SaldoBodega(1)
    End Get
  End Property

  Public ReadOnly Property SaldoBodega3() As Decimal
    Get
      Return SaldoBodega(2)
    End Get
  End Property

  Public ReadOnly Property SaldoBodega4() As Decimal
    Get
      Return SaldoBodega(3)
    End Get
  End Property

  Public ReadOnly Property SaldoBodega5() As Decimal
    Get
      Return SaldoBodega(4)
    End Get
  End Property

  Public ReadOnly Property SaldoBodega6() As Decimal
    Get
      Return SaldoBodega(5)
    End Get
  End Property

  Public ReadOnly Property SaldoBodega7() As Decimal
    Get
      Return SaldoBodega(6)
    End Get
  End Property

  Public ReadOnly Property SaldoBodega8() As Decimal
    Get
      Return SaldoBodega(7)
    End Get
  End Property

  Public ReadOnly Property SaldoBodega9() As Decimal
    Get
      Return SaldoBodega(8)
    End Get
  End Property

  Public ReadOnly Property SaldoBodega10() As Decimal
    Get
      Return SaldoBodega(9)
    End Get
  End Property

  Public ReadOnly Property SaldoBodega11() As Decimal
    Get
      Return SaldoBodega(10)
    End Get
  End Property

  Public ReadOnly Property SaldoBodega12() As Decimal
    Get
      Return SaldoBodega(11)
    End Get
  End Property

  Public ReadOnly Property SaldoBodega13() As Decimal
    Get
      Return SaldoBodega(12)
    End Get
  End Property

  Public ReadOnly Property SaldoBodega14() As Decimal
    Get
      Return SaldoBodega(13)
    End Get
  End Property

  Public ReadOnly Property SaldoBodega15() As Decimal
    Get
      Return SaldoBodega(14)
    End Get
  End Property

  Public ReadOnly Property SaldoBodega16() As Decimal
    Get
      Return SaldoBodega(15)
    End Get
  End Property

  Public ReadOnly Property SaldoBodega17() As Decimal
    Get
      Return SaldoBodega(16)
    End Get
  End Property

  Public ReadOnly Property SaldoBodega18() As Decimal
    Get
      Return SaldoBodega(17)
    End Get
  End Property

  Public ReadOnly Property SaldoBodega19() As Decimal
    Get
      Return SaldoBodega(18)
    End Get
  End Property

  Public ReadOnly Property SaldoBodega20() As Decimal
    Get
      Return SaldoBodega(19)
    End Get
  End Property
#End Region

#Region "Combo"
  Private mDetallesCombo As ItemDetalleList = Nothing
  Public ReadOnly Property DetallesCombo(ByVal _Sucursal As Sucursal) As ItemDetalleList
    Get
      If mDetallesCombo Is Nothing Then
        If EsNuevo Then
          mDetallesCombo = New ItemDetalleList
        Else
          mDetallesCombo = ItemDetalleList.ObtenerLista(Me, _Sucursal)
        End If
      End If
      Return mDetallesCombo
    End Get
  End Property

  Private mDetallesComboEliminados As ItemDetalleList = Nothing
  Public ReadOnly Property DetallesComboEliminados As ItemDetalleList
    Get
      If mDetallesComboEliminados Is Nothing Then
        mDetallesComboEliminados = New ItemDetalleList
      End If
      Return mDetallesComboEliminados
    End Get
  End Property
#End Region

#Region "PrecioxCantidad"
  Private mDetallesPrecioxCantidad As ItemPrecioxCantidadList = Nothing
  Public ReadOnly Property DetallesPrecioxCantidad(ByVal _Sucursal As Sucursal) As ItemPrecioxCantidadList
    Get
      If mDetallesPrecioxCantidad Is Nothing Then
        If EsNuevo Then
          mDetallesPrecioxCantidad = New ItemPrecioxCantidadList
        Else
          mDetallesPrecioxCantidad = ItemPrecioxCantidadList.ObtenerLista(Me, _Sucursal)
        End If
      End If
      Return mDetallesPrecioxCantidad
    End Get
  End Property

  Private mDetallesPrecioxCantidadEliminados As ItemPrecioxCantidadList = Nothing
  Public ReadOnly Property DetallesPrecioxCantidadEliminados As ItemPrecioxCantidadList
    Get
      If mDetallesPrecioxCantidadEliminados Is Nothing Then
        mDetallesPrecioxCantidadEliminados = New ItemPrecioxCantidadList
      End If
      Return mDetallesPrecioxCantidadEliminados
    End Get
  End Property
#End Region

  Public Overridable Sub MapearDataRowaObjeto(ByVal Fila As DataRow)
    Item_Codigo = CType(Fila("Item_Codigo"), Integer)
    Parame_Grupo = CType(Fila("Parame_Grupo"), Integer)
    Pardet_Grupo = CType(Fila("Pardet_Grupo"), Integer)
    Parame_Marca = CType(Fila("Parame_Marca"), Integer)
    Pardet_Marca = CType(Fila("Pardet_Marca"), Integer)
    Parame_Tipoinventario = CType(Fila("Parame_Tipoinventario"), Integer)
    Pardet_Tipoinventario = CType(Fila("Pardet_Tipoinventario"), Integer)
    Item_Aplicaiva = CType(Fila("Item_Aplicaiva"), Boolean)
    Item_Estangible = CType(Fila("Item_Estangible"), Boolean)
    Item_Descripcion = CType(Fila("Item_Descripcion"), String)
    Item_Ubicacion = CType(Fila("Item_Ubicacion"), String)
    Parame_Unidadmedida = CType(Fila("Parame_Unidadmedida"), Integer)
    Pardet_Unidadmedida = CType(Fila("Pardet_Unidadmedida"), Integer)
    Item_CodigoAuxiliar = CType(Fila("Item_CodigoAuxiliar"), String)
    Item_CodigoProveedor = CType(Fila("Item_CodigoProveedor"), String)
    Item_esIvaIncluido = CType(Fila("Item_esIvaIncluido"), Boolean)
    Item_esRegistroSerie = CType(Fila("Item_esRegistroSerie"), Boolean)
    Try
      Entida_Proveedor = CInt(Fila("Entida_Proveedor"))
    Catch ex As Exception
      Entida_Proveedor = 0
    End Try
    Item_Combo = CType(Fila("Item_Combo"), Boolean)
    Item_PrecioxCantidad = CBool(Fila("Item_PrecioxCantidad"))
    mPardetGrupo = Nothing
    mPardetMarca = Nothing
    mPardetTipoInventario = Nothing
    mPardetUnidadMedida = Nothing
    mDetallesCombo = Nothing
    mDetallesComboEliminados = Nothing
    mDetallesPrecioxCantidad = Nothing
    mDetallesPrecioxCantidadEliminados = Nothing
    'mItemxTipoPrecios = Nothing
    'mItemxBodegas = Nothing
  End Sub

  Public Overridable Function Recargar() As Boolean
    Dim Result As New DataTable
    Dim bReturn As Boolean = True
    OperadorDatos.AgregarParametro("@accion", "C")
    OperadorDatos.AgregarParametro("@Item_Codigo", Item_Codigo)
    OperadorDatos.Procedimiento = _Procedimiento
    bReturn = OperadorDatos.Ejecutar(Result)
    OperadorDatos.LimpiarParametros()
    Try
      Me.MapearDataRowaObjeto(Result.Rows(0))
      EsNuevo = False
      EsModificado = False
    Catch ex As System.Exception
      bReturn = False
    End Try
    Return bReturn
  End Function

  Public Overridable Function Guardar() As Boolean
    If Not EsNuevo And Not EsModificado Then
      Return True
    End If
    Dim Result As Integer = 0
    Dim bReturn As Boolean = True

    Dim _comenzotransaccion As Boolean = False
    If Not OperadorDatos.EstaenTransaccion Then
      OperadorDatos.ComenzarTransaccion()
      _comenzotransaccion = True
    End If

    Dim sAccion As String = "M"
    If EsNuevo Then
      sAccion = "I"
    End If
    OperadorDatos.AgregarParametro("@accion", sAccion)
    OperadorDatos.AgregarParametro("@Item_Codigo", Item_Codigo)
    OperadorDatos.AgregarParametro("@Parame_Grupo", Parame_Grupo)
    OperadorDatos.AgregarParametro("@Pardet_Grupo", Pardet_Grupo)
    OperadorDatos.AgregarParametro("@Parame_Marca", Parame_Marca)
    OperadorDatos.AgregarParametro("@Pardet_Marca", Pardet_Marca)
    OperadorDatos.AgregarParametro("@Parame_Tipoinventario", Parame_Tipoinventario)
    OperadorDatos.AgregarParametro("@Pardet_Tipoinventario", Pardet_Tipoinventario)
    OperadorDatos.AgregarParametro("@Item_Aplicaiva", Item_Aplicaiva)
    OperadorDatos.AgregarParametro("@Item_Estangible", Item_Estangible)
    OperadorDatos.AgregarParametro("@Item_Descripcion", Item_Descripcion)
    OperadorDatos.AgregarParametro("@Item_Ubicacion", Item_Ubicacion)
    OperadorDatos.AgregarParametro("@Parame_Unidadmedida", Parame_Unidadmedida)
    OperadorDatos.AgregarParametro("@Pardet_Unidadmedida", Pardet_Unidadmedida)
    OperadorDatos.AgregarParametro("@Item_CodigoAuxiliar", Item_CodigoAuxiliar)
    OperadorDatos.AgregarParametro("@Item_CodigoProveedor", Item_CodigoProveedor)
    OperadorDatos.AgregarParametro("@Item_esIvaIncluido", Item_esIvaIncluido)
    OperadorDatos.AgregarParametro("@Item_esRegistroSerie", Item_esRegistroSerie)
    If Entida_Proveedor > 0 Then
      OperadorDatos.AgregarParametro("@Entida_Proveedor", Entida_Proveedor)
    End If
    OperadorDatos.AgregarParametro("@Item_Combo", Item_Combo)
    OperadorDatos.AgregarParametro("@Item_PrecioxCantidad", Item_PrecioxCantidad)
    OperadorDatos.Procedimiento = _Procedimiento
    bReturn = OperadorDatos.Ejecutar(Result)
    OperadorDatos.LimpiarParametros()
    If bReturn Then
      If EsNuevo Then
        Item_Codigo = Result
      End If
      
      If mDetallesComboEliminados IsNot Nothing Then
        For Each _detalle As ItemDetalle In mDetallesComboEliminados
          If Not _detalle.EsNuevo Then
            _detalle.Item = Me
            If Not _detalle.Eliminar Then
              bReturn = False
            End If
          End If
        Next
      End If
      If mDetallesCombo IsNot Nothing Then
        For Each _detalle As ItemDetalle In mDetallesCombo
          _detalle.Item = Me
          If Not _detalle.Guardar Then
            bReturn = False
          End If
        Next
      End If

      If mDetallesprecioxcantidadEliminados IsNot Nothing Then
        For Each _detalle As ItemPrecioxCantidad In mDetallesPrecioxCantidadEliminados
          If Not _detalle.EsNuevo Then
            _detalle.Item = Me
            If Not _detalle.Eliminar Then
              bReturn = False
            End If
          End If
        Next
      End If
      If mDetallesPrecioxCantidad IsNot Nothing Then
        For Each _detalle As ItemPrecioxCantidad In mDetallesPrecioxCantidad
          _detalle.Item = Me
          If Not _detalle.Guardar Then
            bReturn = False
          End If
        Next
      End If

      If Not OperadorDatos.EstaenTransaccion Then
        AceptarCambios()
      End If

      If mCambio_Imagen Then
        Guardar_Imagen()
      End If
    End If

    If _comenzotransaccion Then
      If bReturn Then
        OperadorDatos.TerminarTransaccion()
        AceptarCambios()
      Else
        OperadorDatos.CancelarTransaccion()
      End If
    End If
    Return bReturn
  End Function

  Public Overridable Sub AceptarCambios()
    EsNuevo = False
    EsModificado = False

    If mDetallesCombo IsNot Nothing Then
      For Each _detalle As ItemDetalle In mDetallesCombo
        _detalle.AceptarCambios()
      Next
    End If
    mDetallesCombo = Nothing
    mDetallesComboEliminados = Nothing

    If mDetallesPrecioxCantidad IsNot Nothing Then
      For Each _detalle As ItemPrecioxCantidad In mDetallesPrecioxCantidad
        _detalle.AceptarCambios()
      Next
    End If
    mDetallesPrecioxCantidad = Nothing
    mDetallesPrecioxCantidadEliminados = Nothing
  End Sub

  Public Overridable Function Guardar_Imagen() As Boolean
    If EsNuevo Then
      Return False
    End If
    If Not mCambio_Imagen Then
      Return True
    End If
    Dim bReturn As Boolean = True
    OperadorDatos.AgregarParametro("@accion", "ps")
    OperadorDatos.AgregarParametro("@Item_Codigo", Item_Codigo)
    OperadorDatos.AgregarParametroImagen("@Item_Imagen", mArchivoImagen)
    OperadorDatos.Procedimiento = _Procedimiento
    bReturn = OperadorDatos.Ejecutar()
    OperadorDatos.LimpiarParametros()
    If bReturn Then
      mItem_Imagen = Nothing
      mCambio_Imagen = False
    End If
    Return bReturn
  End Function

  Public Overridable Function Eliminar() As Boolean
    If EsNuevo Then
      Return True
    End If

    Dim bReturn As Boolean = True
    OperadorDatos.AgregarParametro("@accion", "E")
    OperadorDatos.AgregarParametro("@Item_Codigo", Item_Codigo)
    OperadorDatos.Procedimiento = _Procedimiento
    bReturn = OperadorDatos.Ejecutar
    OperadorDatos.LimpiarParametros()
    Return bReturn
  End Function
End Class
#End Region

#Region "ItemList"
Public Class ItemList
  Inherits BindingList(Of Item)

  Public Shared Function ObtenerLista(ByVal _OperadorDatos As OperadorDatos, Optional ByVal _grupo As WWTSParametroDet = Nothing, Optional ByVal _tipoinventario As WWTSParametroDet = Nothing, Optional ByVal _filtro As String = "") As ItemList
    Dim oResult As ItemList = New ItemList
    Dim bReturn As Boolean
    Dim ds As New DataTable
    With _OperadorDatos
      .AgregarParametro("@Accion", "F")
      If _grupo IsNot Nothing Then
        .AgregarParametro("@Parame_Grupo", _grupo.Parame_Codigo)
        .AgregarParametro("@Pardet_Grupo", _grupo.Pardet_Secuencia)
      End If
      If _tipoinventario IsNot Nothing Then
        .AgregarParametro("@Parame_TipoInventario", _tipoinventario.Parame_Codigo)
        .AgregarParametro("@Pardet_TipoInventario", _tipoinventario.Pardet_Secuencia)
      End If
      .AgregarParametro("@filtro", _filtro)
      .Procedimiento = "proc_Item"
      bReturn = .Ejecutar(ds)
      .LimpiarParametros()
    End With
    If bReturn AndAlso Not ds Is Nothing AndAlso ds.Rows.Count > 0 Then
      For Each _dr As DataRow In ds.Rows
        Dim _fila As New Item(_OperadorDatos, False)
        _fila.MapearDataRowaObjeto(_dr)
        oResult.Add(_fila)
      Next
    End If
    Return oResult
  End Function

  Public Shared Function ObtenerListaxTipoInventario(ByVal _OperadorDatos As OperadorDatos, Optional ByVal _tipoinventario As WWTSParametroDet = Nothing, Optional ByVal _filtro As String = "") As ItemList
    Dim oResult As ItemList = New ItemList
    Dim bReturn As Boolean
    Dim ds As New DataTable
    With _OperadorDatos
      .AgregarParametro("@Accion", "FT")
      If _tipoinventario IsNot Nothing Then
        .AgregarParametro("@Parame_Tipoinventario", _tipoinventario.Parame_Codigo)
        .AgregarParametro("@Pardet_Tipoinventario", _tipoinventario.Pardet_Secuencia)
      End If
      .AgregarParametro("@filtro", _filtro)
      .Procedimiento = "proc_Item"
      bReturn = .Ejecutar(ds)
      .LimpiarParametros()
    End With
    If bReturn AndAlso Not ds Is Nothing AndAlso ds.Rows.Count > 0 Then
      For Each _dr As DataRow In ds.Rows
        Dim _fila As New Item(_OperadorDatos, False)
        _fila.MapearDataRowaObjeto(_dr)
        oResult.Add(_fila)
      Next
    End If
    Return oResult
  End Function

  Public Shared Function ObtenerListaGruposxTipoInventario(ByVal _OperadorDatos As OperadorDatos, ByVal _tipoinventario As WWTSParametroDet, Optional ByVal _filtro As String = "") As WWTSParametroDetList
    Dim oResult As WWTSParametroDetList = New WWTSParametroDetList
    Dim bReturn As Boolean
    Dim ds As New DataTable
    With _OperadorDatos
      .AgregarParametro("@Accion", "LGT")
      If _tipoinventario IsNot Nothing Then
        .AgregarParametro("@Pardet_Tipoinventario", _tipoinventario.Pardet_Secuencia)
      End If
      .AgregarParametro("@filtro", _filtro)
      .Procedimiento = "proc_Item"
      bReturn = .Ejecutar(ds)
      .LimpiarParametros()
    End With
    If bReturn AndAlso Not ds Is Nothing AndAlso ds.Rows.Count > 0 Then
      For Each _dr As DataRow In ds.Rows
        Dim _fila As New WWTSParametroDet(_OperadorDatos, Enumerados.EnumParametros.Grupo, False)
        _fila.MapearDataRowaObjeto(_dr)
        oResult.Add(_fila)
      Next
    End If
    Return oResult
  End Function

  Public Sub New()
  End Sub
End Class
#End Region
