using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs;

internal class TestDTO
{
}
// Create Request DTOs

public class CreateUserRequestDTO
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public int? RoleID { get; set; }
    public bool? IsActive { get; set; }
}

public class CreateRoleRequestDTO
{
    public string RoleName { get; set; }
    public string Description { get; set; }
}

public class CreateTaskRequestDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public DateTime? DueDate { get; set; }
    public int? CreatorID { get; set; }
    public int? AssigneeID { get; set; }
    public int? ProjectID { get; set; }
    // Other properties related to Task creation
}

public class CreateProjectRequestDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? ManagerID { get; set; }
    // Other properties related to Project creation
}

// Update Request DTOs

public class UpdateUserRequestDTO
{
    public int UserID { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public int? RoleID { get; set; }
    public bool? IsActive { get; set; }
    // Other properties to update if needed
}

public class UpdateRoleRequestDTO
{
    public int RoleID { get; set; }
    public string RoleName { get; set; }
    public string Description { get; set; }
    // Other properties to update if needed
}

public class UpdateTaskRequestDTO
{
    public int TaskID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public DateTime? DueDate { get; set; }
    public int? CreatorID { get; set; }
    public int? AssigneeID { get; set; }
    public int? ProjectID { get; set; }
    // Other properties related to Task update
}

public class TaskDTO
{
    public int TaskID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public DateTime? DueDate { get; set; }
    public int? CreatorID { get; set; }
    public int? AssigneeID { get; set; }
    public int? ProjectID { get; set; }
}


public class UpdateProjectRequestDTO
{
    public int ProjectID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? ManagerID { get; set; }
    // Other properties related to Project update
}
// Create more Update Request DTOs as needed for other models

public class UserResponseDTO
{
    public int UserID { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public int? RoleID { get; set; }
    public bool? IsActive { get; set; }
    // Other properties as needed
}

public class RoleResponseDTO
{
    public int RoleID { get; set; }
    public string RoleName { get; set; }
    public string Description { get; set; }
    // Other properties as needed
}

public class TaskResponseDTO
{
    public int TaskID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public DateTime? DueDate { get; set; }
    public int? CreatorID { get; set; }
    public int? AssigneeID { get; set; }
    public int? ProjectID { get; set; }
    // Other properties as needed
}

public class ProjectResponseDTO
{
    public int ProjectID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? ManagerID { get; set; }
    // Other properties as needed
}

// Create more Response DTOs as needed for other models
