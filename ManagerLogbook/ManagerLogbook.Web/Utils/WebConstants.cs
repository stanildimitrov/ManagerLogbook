﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerLogbook.Web.Utils
{
    public static class WebConstants
    {
        public const string SuccessfullyAddNote = "Note created successfully.";
        public const string SuccessfullyUpdateNote = "Note was updated successfully.";
        public const string NoLogbookChoosen = "Please choose a logbook.";
        public const string NoteCreated = "Note was successfully created.";
        public const string NoteEdited = "Note was successfully edited.";
        public const string UnableToEditNote = "Unable to edit note.";
        public const string UnableToDisableStatusNote = "Unable to disable status.";
        public const string SuccessfullyDeactivateActiveStatus = "Note active status was successfully deactivated.";
        public const string BusinessUnitCreated = "Business unit was successfully created.";
        public const string UnableToUpdateBusinessUnit = "Unable to update business unit.";
        public const string BusinessUnitUpdated = "Business unit was successfully updated.";
        public const string BusinessUnitNotCreated = "Unable to create business unit.";
        public const string BusinessUniNotExist = "Business unit does not exists.";
        public const string ModeratorNotExist = "Moderator does not exists.";
        public const string SuccessfullyAddedModeratorToBusinessUnit = "Moderator was successfully added to business unit.";
        public const string ReviewCreated = "Review was successfully created.";
        public const string ReviewNotCreated = "Unable to create review.";        
    }
}
