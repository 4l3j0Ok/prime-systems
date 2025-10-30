using ReaLTaiizor.Controls;
using System.ComponentModel;

namespace PrimeSystems.Views.Controls
{
    /// <summary>
    /// Versión personalizada de MaterialExpansionPanel que deshabilita completamente
    /// la funcionalidad de colapsar/expandir, incluso al hacer clic en la cabecera
    /// y al presionar los botones Save/Cancel.
    /// </summary>
    public class MaterialExpansionPanelNonCollapsible : MaterialExpansionPanel
    {
        private bool _suppressCollapseToggle = false;

        public MaterialExpansionPanelNonCollapsible()
        {
            // Asegurar que el botón de colapsar esté oculto
            this.ShowCollapseExpand = false;
            
            // Suscribirse a los eventos para interceptarlos
            this.SaveClick += OnInternalSaveClick;
            this.CancelClick += OnInternalCancelClick;
        }

        /// <summary>
        /// Intercepta el evento SaveClick para evitar el colapso automático
        /// </summary>
        private void OnInternalSaveClick(object? sender, EventArgs e)
        {
            // Marcar que se debe suprimir el colapso
            _suppressCollapseToggle = true;
        }

        /// <summary>
        /// Intercepta el evento CancelClick para evitar el colapso automático
        /// </summary>
        private void OnInternalCancelClick(object? sender, EventArgs e)
        {
            // Marcar que se debe suprimir el colapso
            _suppressCollapseToggle = true;
        }

        /// <summary>
        /// Sobrescribe el método OnMouseDown para evitar que el clic
        /// en la cabecera colapse/expanda el panel
        /// </summary>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            // No llamar a base.OnMouseDown(e) para evitar el comportamiento de colapso
            // Solo procesar otros eventos de mouse sin el comportamiento de expansión/colapso
        }

        /// <summary>
        /// Sobrescribe el método OnClick para deshabilitar el colapso por click
        /// </summary>
        protected override void OnClick(EventArgs e)
        {
            // No llamar a base.OnClick(e) para evitar el comportamiento de colapso
        }

        /// <summary>
        /// Asegurar que el panel siempre esté expandido
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool Collapse
        {
            get => false;
            set 
            { 
                // Si se está intentando colapsar y debemos suprimirlo, no hacer nada
                if (_suppressCollapseToggle)
                {
                    _suppressCollapseToggle = false; // Resetear la bandera
                    return; // No permitir el colapso
                }
                // No hacer nada en cualquier caso, siempre expandido
            }
        }

        /// <summary>
        /// Sobrescribe la propiedad Height para evitar cambios de tamaño durante colapso
        /// </summary>
        protected override void OnLayout(LayoutEventArgs e)
        {
            // Guardar el estado de expansión antes de llamar al base
            var wasCollapsed = base.Collapse;
            
            base.OnLayout(e);
            
            // Forzar que siempre esté expandido después del layout
            if (base.Collapse != false)
            {
                base.Collapse = false;
            }
        }
    }
}