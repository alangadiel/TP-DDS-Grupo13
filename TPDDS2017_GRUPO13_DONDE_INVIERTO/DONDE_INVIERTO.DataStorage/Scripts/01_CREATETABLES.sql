DROP DATABASE IF EXISTS dondeinvierto
GO

CREATE DATABASE dondeinvierto
GO

USE [dondeinvierto]
GO

CREATE TABLE [dbo].[condicion](
	[cond_id] [int] IDENTITY(1,1),
	[cond_indicador_id] [int] NOT NULL,
	[cond_antiguedad] [int],
	[cond_mayorOMenor] [bit] NOT NULL,
	[cond_consistentementeCreciente] [bit],
	[cond_valorAComparar] [decimal](12,2),
 CONSTRAINT [PK_condicion] PRIMARY KEY CLUSTERED 
(
	[cond_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[condicion_metodologia](
	[come_id] [int] IDENTITY(1,1),
	[come_metodologia_id] [int] NOT NULL,
	[come_condicion_id] [int] NOT NULL,
 CONSTRAINT [PK_condicion_metodologia] PRIMARY KEY CLUSTERED 
(
	[come_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[cuenta](
	[cue_id] [int] IDENTITY(1,1),
	[cue_nombre] [nvarchar](200) NOT NULL,
	[cue_empresa_id] [int] NOT NULL,
 CONSTRAINT [PK_cuenta] PRIMARY KEY CLUSTERED 
(
	[cue_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[cuenta_periodo](
	[cupe_id] [int] IDENTITY(1,1),
	[cupe_valor] [decimal](12,2) NOT NULL,
	[cupe_cuenta_id] [int] NOT NULL,
	[cupe_periodo_id] [int] NOT NULL,
 CONSTRAINT [PK_CuentaXPeriodoSet] PRIMARY KEY CLUSTERED 
(
	[cupe_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[empresa](
	[emp_id] [int] IDENTITY(1,1),
	[emp_fecha_creacion] [datetime] NOT NULL,
	[emp_nombre] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_EmpresaSet] PRIMARY KEY CLUSTERED 
(
	[emp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[indicador](
	[ind_id] [int] IDENTITY(1,1),
	[ind_nombre] [nvarchar](200) NOT NULL,
	[ind_contenido] [nvarchar](200) NOT NULL,
	[ind_usuario_id] [int] NULL,
 CONSTRAINT [PK_indicador] PRIMARY KEY CLUSTERED 
(
	[ind_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[indicador_cuenta](
	[incu_id] [int] IDENTITY(1,1),
	[incu_cuenta_id] [int] NOT NULL,
	[incu_indicador_id] [int] NOT NULL,
 CONSTRAINT [PK_indicador_cuenta] PRIMARY KEY CLUSTERED 
(
	[incu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[metodologia](
	[met_id] [int] IDENTITY(1,1),
	[met_nombre] [nvarchar](200) NOT NULL,
	[met_usuario_id] [int] NULL,
 CONSTRAINT [PK_metodologia] PRIMARY KEY CLUSTERED 
(
	[met_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[periodo](
	[per_id] [int] IDENTITY(1,1),
	[per_anio] [datetime] NOT NULL,
	[per_semestre] [smallint] NOT NULL,
 CONSTRAINT [PK_periodo] PRIMARY KEY CLUSTERED 
(
	[per_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[usuario](
	[usu_id] [int] IDENTITY(1,1) NOT NULL,
	[usu_usuario] [nvarchar](20) NOT NULL,
	[usu_contrasenia] [nvarchar](20) NOT NULL,
	[usu_nombre] [nvarchar](50) NOT NULL,
	[usu_apellido] [nvarchar](50) NOT NULL,
	[usu_fecha_alta] [datetime] NOT NULL
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[usu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE [dbo].[metodologia]  WITH CHECK ADD  CONSTRAINT [FK_metodologia_usuario] FOREIGN KEY([met_usuario_id])
REFERENCES [dbo].[usuario] ([usu_id])
GO

ALTER TABLE [dbo].[metodologia] CHECK CONSTRAINT [FK_metodologia_usuario]
GO

ALTER TABLE [dbo].[indicador]  WITH CHECK ADD  CONSTRAINT [FK_indicador_usuario] FOREIGN KEY([ind_usuario_id])
REFERENCES [dbo].[usuario] ([usu_id])
GO

ALTER TABLE [dbo].[indicador] CHECK CONSTRAINT [FK_indicador_usuario]
GO

ALTER TABLE [dbo].[indicador_cuenta]  WITH CHECK ADD  CONSTRAINT [FK_indicador_cuenta_cuenta] FOREIGN KEY([incu_cuenta_id])
REFERENCES [dbo].[cuenta] ([cue_id])
GO

ALTER TABLE [dbo].[indicador_cuenta] CHECK CONSTRAINT [FK_indicador_cuenta_cuenta]
GO

ALTER TABLE [dbo].[indicador_cuenta]  WITH CHECK ADD  CONSTRAINT [FK_indicador_cuenta_indicador] FOREIGN KEY([incu_indicador_id])
REFERENCES [dbo].[indicador] ([ind_id])
GO

ALTER TABLE [dbo].[indicador_cuenta] CHECK CONSTRAINT [FK_indicador_cuenta_indicador]
GO




ALTER TABLE [dbo].[cuenta_periodo]  WITH CHECK ADD  CONSTRAINT [FK_cuenta_periodo_cuenta] FOREIGN KEY([cupe_cuenta_id])
REFERENCES [dbo].[cuenta] ([cue_id])
GO

ALTER TABLE [dbo].[cuenta_periodo] CHECK CONSTRAINT [FK_cuenta_periodo_cuenta]
GO

ALTER TABLE [dbo].[cuenta_periodo]  WITH CHECK ADD  CONSTRAINT [FK_cuenta_periodo_periodo] FOREIGN KEY([cupe_periodo_id])
REFERENCES [dbo].[periodo] ([per_id])
GO

ALTER TABLE [dbo].[cuenta_periodo] CHECK CONSTRAINT [FK_cuenta_periodo_periodo]
GO


ALTER TABLE [dbo].[cuenta]  WITH CHECK ADD  CONSTRAINT [FK_cuenta_empresa] FOREIGN KEY([cue_empresa_id])
REFERENCES [dbo].[empresa] ([emp_id])
GO

ALTER TABLE [dbo].[cuenta] CHECK CONSTRAINT [FK_cuenta_empresa]
GO


ALTER TABLE [dbo].[condicion_metodologia]  WITH CHECK ADD  CONSTRAINT [FK_condicion_metodologia_condicion] FOREIGN KEY([come_condicion_id])
REFERENCES [dbo].[condicion] ([cond_id])
GO

ALTER TABLE [dbo].[condicion_metodologia] CHECK CONSTRAINT [FK_condicion_metodologia_condicion]
GO

ALTER TABLE [dbo].[condicion_metodologia]  WITH CHECK ADD  CONSTRAINT [FK_condicion_metodologia_metodologia] FOREIGN KEY([come_metodologia_id])
REFERENCES [dbo].[metodologia] ([met_id])
GO

ALTER TABLE [dbo].[condicion_metodologia] CHECK CONSTRAINT [FK_condicion_metodologia_metodologia]
GO

ALTER TABLE [dbo].[condicion]  WITH CHECK ADD  CONSTRAINT [FK_condicion_indicador] FOREIGN KEY(cond_indicador_id)
REFERENCES [dbo].[indicador] ([ind_id])
GO

ALTER TABLE [dbo].[condicion] CHECK CONSTRAINT [FK_condicion_indicador]
GO


