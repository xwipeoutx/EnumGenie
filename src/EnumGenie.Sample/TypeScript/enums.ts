export const enum CustomValues {
    First = 2,
    Second = 4,
    Third = 100
}
export function customValuesDescription(value: CustomValues) {
    switch (value) {
        case CustomValues.First:
            return `First`;
        case CustomValues.Second:
            return `Second`;
        case CustomValues.Third:
            return `Third`;
    }
}
export interface ICustomValuesDescriptor { value: CustomValues; name: string; description: string; }
export const allCustomValues: ICustomValuesDescriptor[] = [
    { value: CustomValues.First, name: `First`, description: `First` },
    { value: CustomValues.Second, name: `Second`, description: `Second` },
    { value: CustomValues.Third, name: `Third`, description: `Third` }
];

export function getCustomValuesDescriptor(value: CustomValues) {
    switch (value) {
        case CustomValues.First:
            return { value: CustomValues.First, name: `First`, description: `First` };
        case CustomValues.Second:
            return { value: CustomValues.Second, name: `Second`, description: `Second` };
        case CustomValues.Third:
            return { value: CustomValues.Third, name: `Third`, description: `Third` };
    }
}
export const enum Descriptions {
    First = 0,
    Second = 1,
    Third = 2
}
export function descriptionsDescription(value: Descriptions) {
    switch (value) {
        case Descriptions.First:
            return `Number 1`;
        case Descriptions.Second:
            return `Number 2`;
        case Descriptions.Third:
            return `Number 3`;
    }
}
export interface IDescriptionsDescriptor { value: Descriptions; name: string; description: string; }
export const allDescriptions: IDescriptionsDescriptor[] = [
    { value: Descriptions.First, name: `First`, description: `Number 1` },
    { value: Descriptions.Second, name: `Second`, description: `Number 2` },
    { value: Descriptions.Third, name: `Third`, description: `Number 3` }
];

export function getDescriptionsDescriptor(value: Descriptions) {
    switch (value) {
        case Descriptions.First:
            return { value: Descriptions.First, name: `First`, description: `Number 1` };
        case Descriptions.Second:
            return { value: Descriptions.Second, name: `Second`, description: `Number 2` };
        case Descriptions.Third:
            return { value: Descriptions.Third, name: `Third`, description: `Number 3` };
    }
}
export const enum Flags {
    None = 0,
    First = 1,
    Second = 2,
    Third = 4
}
export function flagsDescription(value: Flags) {
    switch (value) {
        case Flags.None:
            return `None`;
        case Flags.First:
            return `First`;
        case Flags.Second:
            return `Second`;
        case Flags.Third:
            return `Third`;
    }
}
export interface IFlagsDescriptor { value: Flags; name: string; description: string; }
export const allFlags: IFlagsDescriptor[] = [
    { value: Flags.First, name: `First`, description: `First` },
    { value: Flags.Second, name: `Second`, description: `Second` },
    { value: Flags.Third, name: `Third`, description: `Third` }
];

export function getFlagsDescriptor(value: Flags) {
    switch (value) {
        case Flags.First:
            return { value: Flags.First, name: `First`, description: `First` };
        case Flags.Second:
            return { value: Flags.Second, name: `Second`, description: `Second` };
        case Flags.Third:
            return { value: Flags.Third, name: `Third`, description: `Third` };
    }
}
export const enum Renamed {
    First = 0,
    Second = 1,
    Third = 2
}
export function renamedDescription(value: Renamed) {
    switch (value) {
        case Renamed.First:
            return `First`;
        case Renamed.Second:
            return `Second`;
        case Renamed.Third:
            return `Third`;
    }
}
export interface IRenamedDescriptor { value: Renamed; name: string; description: string; }
export const allRenamed: IRenamedDescriptor[] = [
    { value: Renamed.First, name: `First`, description: `First` },
    { value: Renamed.Second, name: `Second`, description: `Second` },
    { value: Renamed.Third, name: `Third`, description: `Third` }
];

export function getRenamedDescriptor(value: Renamed) {
    switch (value) {
        case Renamed.First:
            return { value: Renamed.First, name: `First`, description: `First` };
        case Renamed.Second:
            return { value: Renamed.Second, name: `Second`, description: `Second` };
        case Renamed.Third:
            return { value: Renamed.Third, name: `Third`, description: `Third` };
    }
}
export const enum Standard {
    First = 0,
    Second = 1,
    Third = 2
}
export function standardDescription(value: Standard) {
    switch (value) {
        case Standard.First:
            return `First`;
        case Standard.Second:
            return `Second`;
        case Standard.Third:
            return `Third`;
    }
}
export interface IStandardDescriptor { value: Standard; name: string; description: string; }
export const allStandard: IStandardDescriptor[] = [
    { value: Standard.First, name: `First`, description: `First` },
    { value: Standard.Second, name: `Second`, description: `Second` },
    { value: Standard.Third, name: `Third`, description: `Third` }
];

export function getStandardDescriptor(value: Standard) {
    switch (value) {
        case Standard.First:
            return { value: Standard.First, name: `First`, description: `First` };
        case Standard.Second:
            return { value: Standard.Second, name: `Second`, description: `Second` };
        case Standard.Third:
            return { value: Standard.Third, name: `Third`, description: `Third` };
    }
}
